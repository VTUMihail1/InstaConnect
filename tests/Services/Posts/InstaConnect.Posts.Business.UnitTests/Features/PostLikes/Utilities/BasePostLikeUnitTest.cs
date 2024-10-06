using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Mappings;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest : BaseSharedUnitTest
{
    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostLikeReadRepository PostLikeReadRepository { get; }

    protected IPostLikeWriteRepository PostLikeWriteRepository { get; }

    public BasePostLikeUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostLikeQueryProfile>();
                    cfg.AddProfile<PostLikeCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostLikeReadRepository = Substitute.For<IPostLikeReadRepository>();
        PostLikeWriteRepository = Substitute.For<IPostLikeWriteRepository>();

        var existingUser = new User(
            PostLikeTestUtilities.ValidUserFirstName,
            PostLikeTestUtilities.ValidUserLastName,
            PostLikeTestUtilities.ValidUserEmail,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidUserProfileImage)
        {
            Id = PostLikeTestUtilities.ValidCurrentUserId,
        };

        var existingPostLikeUser = new User(
            PostLikeTestUtilities.ValidUserFirstName,
            PostLikeTestUtilities.ValidUserLastName,
            PostLikeTestUtilities.ValidUserEmail,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidUserProfileImage)
        {
            Id = PostLikeTestUtilities.ValidPostLikeCurrentUserId,
        };

        var existingPost = new Post(
            PostLikeTestUtilities.ValidPostTitle,
            PostLikeTestUtilities.ValidPostContent,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId)
        {
            Id = PostLikeTestUtilities.ValidPostId,
            User = existingPostLikeUser,
        };

        var existingPostLikePost = new Post(
            PostLikeTestUtilities.ValidPostTitle,
            PostLikeTestUtilities.ValidPostContent,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId)
        {
            Id = PostLikeTestUtilities.ValidPostLikePostId,
            User = existingPostLikeUser,
        };

        var existingPostLike = new PostLike(
            PostLikeTestUtilities.ValidPostLikePostId,
            PostLikeTestUtilities.ValidPostLikeCurrentUserId)
        {
            Id = PostLikeTestUtilities.ValidId,
            User = existingPostLikeUser,
            Post = existingPostLikePost,
        };

        var existingPostLikePaginationList = new PaginationList<PostLike>(
            [existingPostLike],
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue,
            PostLikeTestUtilities.ValidTotalCountValue);

        UserWriteRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidPostLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostLikeUser);

        PostReadRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostWriteRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostReadRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLikePost);

        PostWriteRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLikePost);

        PostLikeReadRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeWriteRepository.GetByIdAsync(
            PostLikeTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeWriteRepository.GetByUserIdAndPostIdAsync(
            PostLikeTestUtilities.ValidPostLikeCurrentUserId,
            PostLikeTestUtilities.ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeReadRepository
            .GetAllAsync(Arg.Is<PostLikeCollectionReadQuery>(m =>
                                                                        m.PostId == PostLikeTestUtilities.ValidPostLikePostId &&
                                                                        m.UserId == PostLikeTestUtilities.ValidPostLikeCurrentUserId &&
                                                                        m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(existingPostLikePaginationList);
    }
}
