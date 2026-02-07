namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender sender,
        GetAllPostCommentsApiRequest request,
        Post post,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
            .ReturnsResponse(postComments.ToResponse(post, request));
    }

    public static void SetupGetAllForUserQueryRequest(
        this IApplicationSender sender,
        GetAllPostCommentsForUserApiRequest request,
        User user,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken)
            .ReturnsResponse(postComments.ToResponse(user, request));
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender sender,
        GetPostCommentByIdApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender sender,
        AddPostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender sender,
        UpdatePostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        sender
            .SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }
}
