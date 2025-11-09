namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetAllPostCommentLikesQueryRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        var postCommentLikes = new List<PostCommentLike>() { postCommentLike };
        var response = new PostCommentLikeCollection(
            postCommentLikes,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentLikes.Count,
            false,
            false);

        postCommentLikeService
            .GetAllAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentLikeService postCommentLikeService,
        GetPostCommentLikeByIdQueryRequest request,
        PostCommentLike postCommentLike,
        User user,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .GetByIdAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQuery(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }

    public static void SetupAddCommand(
        this IPostCommentLikeService postCommentLikeService,
        AddPostCommentLikeCommandRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        postCommentLikeService
            .AddAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommand(request), cancellationToken)
            .ReturnsResponse(postCommentLike);
    }
}
