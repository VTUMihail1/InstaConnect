namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentService postCommentService,
        GetAllPostCommentsQueryRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var postComments = new List<PostComment>() { postComment };
        var response = new PostCommentCollection(
            postComments,
            request.Page,
            request.PageSize,
            postComments.Count,
            false,
            false);

        postCommentService
            .GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
            .ReturnsResponse(response);
    }

    public static void SetupGetByIdQuery(
        this IPostCommentService postCommentService,
        GetPostCommentByIdQueryRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupAddCommand(
        this IPostCommentService postCommentService,
        AddPostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }

    public static void SetupUpdateCommand(
        this IPostCommentService postCommentService,
        UpdatePostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        postCommentService
            .UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment);
    }
}
