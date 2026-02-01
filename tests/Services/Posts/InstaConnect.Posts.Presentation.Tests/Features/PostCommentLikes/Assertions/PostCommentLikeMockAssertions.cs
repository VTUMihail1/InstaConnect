using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentLikesForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommandRequest(request), cancellationToken);
    }
}
