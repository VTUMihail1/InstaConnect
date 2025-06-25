using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostLikeService PostLikeService { get; }

    protected BasePostLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        ApplicationMapper = new ApplicationMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostLikeService = Substitute.For<IPostLikeService>();
    }

    private User CreateUserUtil()
    {
        var user = UserTestUtilities.CreateUser();

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private Post CreatePostUtil(User user)
    {
        var post = PostTestUtilities.CreatePost(user, [], []);

        var postPaginationList = new PaginationList<Post>(
            [post],
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue,
            PostTestUtilities.ValidTotalCountValue);

        PostReadRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        PostWriteRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        PostReadRepository
            .GetAllAsync(Arg.Is<GetAllPostsRequest>(m =>
                                                                        m.Title == post.Title &&
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == PostTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postPaginationList);

        return post;
    }

    protected Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    private PostLike CreatePostLikeUtil(User user, Post post)
    {
        var postLike = PostLikeTestUtilities.CreatePostLike(user, post);

        var postLikePaginationList = new PaginationList<PostLike>(
        [postLike],
        PostLikeTestUtilities.ValidPageValue,
        PostLikeTestUtilities.ValidPageSizeValue,
        PostLikeTestUtilities.ValidTotalCountValue);

        PostLikeService.GetByIdAsync(post, postLike.Id, CancellationToken)
            .Returns(postLike);

        PostLikeService
            .GetAllAsync(post, Arg.Is<PostLikeCollectionReadQuery>(m => m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postLikePaginationList);

        return postLike;
    }

    protected PostLike CreatePostLike()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postLike = CreatePostLikeUtil(user, post);

        return postLike;
    }

    protected PostLike CreatePostLikeFactory()
    {
        var user = CreateUser();

        var post = PostTestUtilities.CreatePost(user, [], []);
        var postLike = PostLikeTestUtilities.CreatePostLike(user, post);

        PostLikeService.AddAsync(post, user.Id, CancellationToken)
            .Returns(postLike);

        return postLike;
    }
}
