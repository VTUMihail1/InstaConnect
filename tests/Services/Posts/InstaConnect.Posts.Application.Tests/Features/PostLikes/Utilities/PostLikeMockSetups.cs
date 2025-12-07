namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
public static class PostLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostLikeService postLikeService,
        GetAllPostLikesQueryRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var postLikes = new List<PostLike>() { postLike };
        var response = new PostLikeCollection(
            postLikes,
            request.Page,
            request.PageSize,
            postLikes.Count,
            false,
            false);

        postLikeService
            .GetAllAsync(PostLikeMatcher.IsGetAllPostLikesQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostLikeService postLikeService,
        GetPostLikeByIdQueryRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        postLikeService
            .GetByIdAsync(PostLikeMatcher.IsGetPostLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postLike);
    }

    public static void SetupAddCommand(
        this IPostLikeService postLikeService,
        AddPostLikeCommandRequest request,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        postLikeService
            .AddAsync(PostLikeMatcher.IsAddPostLikeCommand(request), cancellationToken)
            .ReturnsResponse(postLike);
    }
}
