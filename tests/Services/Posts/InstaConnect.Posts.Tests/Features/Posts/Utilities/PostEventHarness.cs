using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostEventHarness
{
    public static async Task<bool> HasPublishPostAddedEventAsync(
        this IEventHarness eventHarness,
        Post post,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostAddedEventRequest>(p => p.Id == post.Id &&
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
        var result = await eventHarness.PublishedAsync<PostUpdatedEventRequest>(p => p.Id == post.Id &&
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
        var result = await eventHarness.PublishedAsync<PostDeletedEventRequest>(p => p.Id == post.Id, cancellationToken);

        return result;
    }
}
