using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostLikesForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsDeletePostLikeCommandRequest(request), cancellationToken);
    }
}
