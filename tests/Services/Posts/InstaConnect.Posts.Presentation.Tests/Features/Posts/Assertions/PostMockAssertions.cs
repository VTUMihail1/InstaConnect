using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostsForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsDeletePostCommandRequest(request), cancellationToken);
    }
}
