namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender sender,
        GetAllPostCommentLikesApiRequest request,
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLikes.ToResponse(postComment, request));
    }

    public static void SetupGetAllForUserQueryRequest(
        this IApplicationSender sender,
        GetAllPostCommentLikesForUserApiRequest request,
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLikes.ToResponse(user, request));
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender sender,
        GetPostCommentLikeByIdApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLike.ToResponse(request));
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender sender,
        AddPostCommentLikeApiRequest request,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken)
            .ReturnsResponse(postCommentLike.ToResponse(request));
    }
}
