using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostCommentService postCommentService,
        GetAllPostCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceived(1).GetAllAsync(PostCommentMatcher.IsGetAllPostCommentsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostCommentService postCommentService,
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceived(1).GetByIdAsync(PostCommentMatcher.IsGetPostCommentByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommentService postCommentService,
        AddPostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceived(1).AddAsync(PostCommentMatcher.IsAddPostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostCommentService postCommentService,
        UpdatePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceived(1).UpdateAsync(PostCommentMatcher.IsUpdatePostCommentCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommentService postCommentService,
        DeletePostCommentCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postCommentService.ShouldHaveReceived(1).DeleteAsync(PostCommentMatcher.IsDeletePostCommentCommand(request), cancellationToken);
    }
}
