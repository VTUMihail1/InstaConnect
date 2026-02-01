using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
public static class PostCommentMockSetups
{
    public static void SetupGetAllQuery(
        this IPostCommentQueryService commentService,
        GetAllPostCommentsQueryRequest request,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        commentService
            .GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken)
            .ReturnsResponse(postComments.ToResponse(request));
    }

    public static void SetupGetAllForUserQuery(
        this IPostCommentQueryService commentService,
        GetAllPostCommentsForUserQueryRequest request,
        ICollection<PostComment> postComments,
        CancellationToken cancellationToken)
    {
        commentService
            .GetAllForUserAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken)
            .ReturnsResponse(postComments.ToResponse(request));
    }

    public static void SetupGetByIdQuery(
        this IPostCommentQueryService commentService,
        GetPostCommentByIdQueryRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        commentService
            .GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }

    public static void SetupAddCommand(
        this IPostCommentCommandService commentService,
        AddPostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        commentService
            .AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }

    public static void SetupUpdateCommand(
        this IPostCommentCommandService commentService,
        UpdatePostCommentCommandRequest request,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        commentService
            .UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken)
            .ReturnsResponse(postComment.ToResponse(request));
    }
}
