using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostCommentLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostCommentLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }
}
