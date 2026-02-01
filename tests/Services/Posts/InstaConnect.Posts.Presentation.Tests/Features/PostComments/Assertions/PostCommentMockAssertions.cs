using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetAllPostCommentsForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetAllPostCommentsForUserQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsGetPostCommentByIdQueryRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsAddPostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsUpdatePostCommentCommandRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.ShouldHaveReceivedOne().SendAsync(PostCommentMatcher.IsDeletePostCommentCommandRequest(request), cancellationToken);
    }
}
