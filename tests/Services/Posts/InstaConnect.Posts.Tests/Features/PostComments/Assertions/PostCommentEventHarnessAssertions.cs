using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedUpdatedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }
}
