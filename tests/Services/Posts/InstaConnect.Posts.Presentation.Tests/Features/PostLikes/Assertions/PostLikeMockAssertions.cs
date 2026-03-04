using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostLikesForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetAllPostLikesForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsGetPostLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsAddPostLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostLikeMatcher.IsDeletePostLikeCommandRequest(request), cancellationToken);
    }
}
