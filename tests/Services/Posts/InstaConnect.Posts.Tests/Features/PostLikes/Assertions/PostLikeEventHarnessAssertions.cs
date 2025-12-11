using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }
}
