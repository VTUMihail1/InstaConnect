using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostLikeQueryService likeService,
        GetAllPostLikesQueryRequest request,
        Post post,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        likeService
            .GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken)
            .ReturnsResponse(postLikes.ToResponse(post, request));
    }

    public static void SetupGetAllForUserQuery(
        this IPostLikeQueryService likeService,
        GetAllPostLikesForUserQueryRequest request,
        User user,
        ICollection<PostLike> postLikes,
        CancellationToken cancellationToken)
    {
        likeService
            .GetAllForUserAsync(PostLikeMatcher.IsGetAllPostLikesForUserQuery(request), cancellationToken)
            .ReturnsResponse(postLikes.ToResponse(user, request));
    }

    public static void SetupGetByIdQuery(
        this IPostLikeQueryService likeService,
        GetPostLikeByIdQueryRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        likeService
            .GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postLike.ToResponse(request));
    }

    public static void SetupAddCommand(
        this IPostLikeCommandService likeService,
        AddPostLikeCommandRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        likeService
            .AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken)
            .ReturnsResponse(postLike.ToResponse(request));
    }
}
