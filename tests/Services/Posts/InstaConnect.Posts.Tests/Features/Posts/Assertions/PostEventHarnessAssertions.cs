using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedUpdatedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
            p => p.Matches(entity),
            cancellationToken);
    }
}
