using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceived(1).SendAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommandRequest(request), cancellationToken);
    }
}
