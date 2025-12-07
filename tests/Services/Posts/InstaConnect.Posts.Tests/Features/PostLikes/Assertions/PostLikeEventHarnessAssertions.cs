using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(p => p.Id == entity.Id.Id.Id &&
                                                                                    p.UserId == entity.Id.UserId.Id &&
                                                                                    p.CreatedAtUtc == entity.CreatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(p => p.Id == entity.Id.Id.Id &&
                                                                                      p.UserId == entity.Id.UserId.Id, cancellationToken);
    }
}
