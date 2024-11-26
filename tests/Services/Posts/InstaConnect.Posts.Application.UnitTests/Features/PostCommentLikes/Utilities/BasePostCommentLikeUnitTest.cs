using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest : BaseSharedUnitTest
{
    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    protected IPostCommentLikeReadRepository PostCommentLikeReadRepository { get; }

    protected IPostCommentLikeWriteRepository PostCommentLikeWriteRepository { get; }

    public BasePostCommentLikeUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentLikeQueryProfile>();
                    cfg.AddProfile<PostCommentLikeCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {

        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();
        PostCommentLikeReadRepository = Substitute.For<IPostCommentLikeReadRepository>();
        PostCommentLikeWriteRepository = Substitute.For<IPostCommentLikeWriteRepository>();

        var existingUser = new User(
            PostCommentLikeTestUtilities.ValidUserFirstName,
            PostCommentLikeTestUtilities.ValidUserLastName,
            PostCommentLikeTestUtilities.ValidUserEmail,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidUserProfileImage)
        {
            Id = PostCommentLikeTestUtilities.ValidCurrentUserId,
        };

        var existingPostCommentLikeUser = new User(
            PostCommentLikeTestUtilities.ValidUserFirstName,
            PostCommentLikeTestUtilities.ValidUserLastName,
            PostCommentLikeTestUtilities.ValidUserEmail,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidUserProfileImage)
        {
            Id = PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
        };

        var existingPostComment = new PostComment(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            PostCommentLikeTestUtilities.ValidPostCommentContent
            )
        {
            Id = PostCommentLikeTestUtilities.ValidPostCommentId,
            User = existingPostCommentLikeUser
        };

        var existingPostCommentLikePostComment = new PostComment(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            PostCommentLikeTestUtilities.ValidPostCommentContent
            )
        {
            Id = PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            User = existingPostCommentLikeUser,
        };

        var existingPostCommentLike = new PostCommentLike(
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId)
        {
            Id = PostCommentLikeTestUtilities.ValidId,
            User = existingPostCommentLikeUser,
            PostComment = existingPostCommentLikePostComment,
        };

        var existingPostCommentLikePaginationList = new PaginationList<PostCommentLike>(
            [existingPostCommentLike],
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue,
            PostCommentLikeTestUtilities.ValidTotalCountValue);

        UserWriteRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostCommentLikeUser);

        PostCommentReadRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentWriteRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentReadRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLikePostComment);

        PostCommentWriteRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLikePostComment);

        PostCommentLikeReadRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeWriteRepository.GetByIdAsync(
            PostCommentLikeTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeWriteRepository.GetByUserIdAndPostCommentIdAsync(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeReadRepository
            .GetAllAsync(Arg.Is<PostCommentLikeCollectionReadQuery>(m =>
                                                                        m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId &&
                                                                        m.UserId == PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId &&
                                                                        m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                                        m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(existingPostCommentLikePaginationList);
    }
}
