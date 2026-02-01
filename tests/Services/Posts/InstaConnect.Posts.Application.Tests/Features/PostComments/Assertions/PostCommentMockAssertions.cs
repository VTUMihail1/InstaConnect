using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentQueryService postCommentService,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllForUserAsync(
        this IPostCommentQueryService postCommentService,
        GetAllPostCommentsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().GetAllForUserAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentQueryService postCommentService,
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommentCommandService postCommentService,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostCommentCommandService postCommentService,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommentCommandService postCommentService,
        DeletePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceivedOne().DeleteAsync(PostCommentMatcher.IsDeletePostCommentCommand(request), cancellationToken);
    }
}
