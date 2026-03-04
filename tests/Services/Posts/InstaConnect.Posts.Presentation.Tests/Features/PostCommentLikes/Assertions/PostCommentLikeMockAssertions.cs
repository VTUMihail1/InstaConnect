using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostCommentLikesForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommandRequest(request), cancellationToken);
    }
}
