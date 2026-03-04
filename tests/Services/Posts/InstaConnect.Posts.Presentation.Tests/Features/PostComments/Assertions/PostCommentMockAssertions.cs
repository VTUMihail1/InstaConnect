using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetAllPostCommentsForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender sender,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsDeletePostCommentCommandRequest(request), cancellationToken);
    }
}
