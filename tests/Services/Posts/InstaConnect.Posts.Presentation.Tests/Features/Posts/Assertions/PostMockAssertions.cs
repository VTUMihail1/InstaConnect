using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostsForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsDeletePostCommandRequest(request), cancellationToken);
    }
}
