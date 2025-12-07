using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(p => p.Id == entity.Id.Id &&
                                                                                p.UserId == entity.UserId.Id &&
                                                                                p.Title == entity.Title &&
                                                                                p.Content == entity.Content &&
                                                                                p.CreatedAtUtc == entity.CreatedAtUtc &&
                                                                                p.UpdatedAtUtc == entity.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedUpdatedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(p => p.Id == entity.Id.Id &&
                                                                                p.UserId == entity.UserId.Id &&
                                                                                p.Title == entity.Title &&
                                                                                p.Content == entity.Content &&
                                                                                p.UpdatedAtUtc == entity.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        Post entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(p => p.Id == entity.Id.Id, cancellationToken);
    }
}
