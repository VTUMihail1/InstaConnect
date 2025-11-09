using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostLikeMatcher.IsDeletePostLikeCommandRequest(request), cancellationToken);
    }
}
