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
        var result = await eventHarness.PublishedAsync<PostAddedEvent>(p =>
                        p.Id == post.Id &&
                        p.Title == post.Title &&
                        p.Content == post.Content &&
                        p.UserId == post.UserId &&
                        p.CreatedAt == post.CreatedAt &&
                        p.UpdatedAt == post.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostUpdatedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostUpdatedEvent>(p =>
                        p.Id == post.Id &&
                        p.Title == post.Title &&
                        p.Content == post.Content &&
                        p.UserId == post.UserId &&
                        p.CreatedAt == post.CreatedAt &&
                        p.UpdatedAt == post.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostDeletedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostDeletedEvent>(p =>
                        p.Id == post.Id, cancellationToken);

        return result;
    }
}
