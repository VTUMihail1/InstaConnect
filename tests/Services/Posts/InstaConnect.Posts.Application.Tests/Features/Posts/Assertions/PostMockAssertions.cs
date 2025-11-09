using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostService postService,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceived(1).GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostService postService,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceived(1).GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostService postService,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceived(1).AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostService postService,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceived(1).UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostService postService,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceived(1).DeleteAsync(PostMatcher.IsDeletePostCommand(request), cancellationToken);
    }
}
