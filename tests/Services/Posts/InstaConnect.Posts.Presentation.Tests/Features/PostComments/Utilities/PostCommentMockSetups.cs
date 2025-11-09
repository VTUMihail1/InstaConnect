namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQueryRequest(
        this IApplicationSender applicationSender,
        GetAllPostCommentsApiRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {

        var postCommentQueryResponse = new PostCommentQueryResponse(
            postComment.Id,
            postComment.CommentId,
            postComment.Content,
            new(
                user.Id,
                user.Name,
                user.ProfileImage));
        var postCommentQueryResponses = new List<PostCommentQueryResponse>() { postCommentQueryResponse };

        var response = new GetAllPostCommentsQueryResponse(
            postCommentQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postCommentQueryResponses.Count,
            false,
            false);

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQueryRequest(
        this IApplicationSender applicationSender,
        GetPostCommentByIdApiRequest request,
        PostComment postComment,
        User user,
        CancellationToken cancellationToken)
    {
        var response = new GetPostCommentByIdQueryResponse(
            new(
                postComment.Id,
                postComment.CommentId,
                postComment.Content,
                new(
                    user.Id,
                    user.Name,
                    user.ProfileImage)));

        applicationSender
            .SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupAddCommandRequest(
        this IApplicationSender applicationSender,
        AddPostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new AddPostCommentCommandResponse(postComment.Id, postComment.CommentId, postComment.CreatedAt, postComment.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupUpdateCommandRequest(
        this IApplicationSender applicationSender,
        UpdatePostCommentApiRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var response = new UpdatePostCommentCommandResponse(postComment.Id, postComment.CommentId, postComment.CreatedAt, postComment.UpdatedAt);

        applicationSender
            .SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken)
            .ReturnsResponse(response);
    }
}
