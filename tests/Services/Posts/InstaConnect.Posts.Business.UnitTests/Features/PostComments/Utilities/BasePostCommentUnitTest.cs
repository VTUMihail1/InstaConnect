using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Mappings;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest : BaseSharedUnitTest
{
    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    public BasePostCommentUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentQueryProfile>();
                    cfg.AddProfile<PostCommentCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();

        var existingUser = new User(
            PostCommentTestUtilities.ValidUserFirstName,
            PostCommentTestUtilities.ValidUserLastName,
            PostCommentTestUtilities.ValidUserEmail,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidUserProfileImage)
        {
            Id = PostCommentTestUtilities.ValidCurrentUserId,
        };

        var existingPostCommentUser = new User(
            PostCommentTestUtilities.ValidUserFirstName,
            PostCommentTestUtilities.ValidUserLastName,
            PostCommentTestUtilities.ValidUserEmail,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidUserProfileImage)
        {
            Id = PostCommentTestUtilities.ValidPostCommentCurrentUserId,
        };

        var existingPost = new Post(
            PostCommentTestUtilities.ValidPostTitle,
            PostCommentTestUtilities.ValidPostContent,
            PostCommentTestUtilities.ValidCurrentUserId)
        {
            Id = PostCommentTestUtilities.ValidPostId,
        };

        var existingPostCommentPost = new Post(
            PostCommentTestUtilities.ValidPostTitle,
            PostCommentTestUtilities.ValidPostContent,
            PostCommentTestUtilities.ValidCurrentUserId)
        {
            Id = PostCommentTestUtilities.ValidPostCommentPostId,
        };

        var existingPostComment = new PostComment(
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            PostCommentTestUtilities.ValidPostCommentPostId,
            PostCommentTestUtilities.ValidContent)
        {
            Id = PostCommentTestUtilities.ValidId,
            User = existingPostCommentUser,
            Post = existingPostCommentPost
        };

        var existingPostCommentPaginationList = new PaginationList<PostComment>(
            [existingPostComment],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        PostCommentReadRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentWriteRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostComment);

        UserWriteRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidPostCommentCurrentUserId,
            CancellationToken)
            .Returns(existingPostCommentUser);

        PostReadRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostReadRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidPostCommentPostId,
            CancellationToken)
            .Returns(existingPostCommentPost);

        PostWriteRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostWriteRepository.GetByIdAsync(
            PostCommentTestUtilities.ValidPostCommentPostId,
            CancellationToken)
            .Returns(existingPostCommentPost);

        PostCommentReadRepository
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.PostId == PostCommentTestUtilities.ValidPostCommentPostId &&
                                                                        m.UserId == PostCommentTestUtilities.ValidPostCommentCurrentUserId &&
                                                                        m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostCommentPaginationList);
    }
}
