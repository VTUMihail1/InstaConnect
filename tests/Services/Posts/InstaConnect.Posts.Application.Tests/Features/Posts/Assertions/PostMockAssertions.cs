using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
    public static async Task ShouldReceiveOneGetAllAsync(
        this IPostQueryService postService,
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().GetAllAsync(PostMatcher.IsGetAllPostsQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetAllForUserAsync(
        this IPostQueryService postService,
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().GetAllForUserAsync(PostMatcher.IsGetAllPostsForUserQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneGetByIdAsync(
        this IPostQueryService postService,
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().GetByIdAsync(PostMatcher.IsGetPostByIdQuery(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IPostCommandService postService,
        AddPostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().AddAsync(PostMatcher.IsAddPostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IPostCommandService postService,
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().UpdateAsync(PostMatcher.IsUpdatePostCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IPostCommandService postService,
        DeletePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        await postService.ShouldHaveReceivedOne().DeleteAsync(PostMatcher.IsDeletePostCommand(request), cancellationToken);
    }
}
