using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostEventHarness
{
    public static async Task<bool> HasPublishPostAddedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostAddedEvent>(p => p.IsSatisfied(post), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostUpdatedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostUpdatedEvent>(p => p.IsSatisfied(post), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostDeletedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostDeletedEvent>(p => p.IsSatisfied(post), cancellationToken);

        return result;
    }
}
