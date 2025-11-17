using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEventHarness
{
    public static async Task<bool> HasPublishPostLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeAddedEventRequest>(p => p.Id == postLike.Id &&
                                                                                p.UserId == postLike.UserId &&
                                                                                p.CreatedAtUtc == postLike.CreatedAtUtc &&
                                                                                p.UpdatedAt == postLike.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostLikeDeletedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeDeletedEventRequest>(p => p.Id == postLike.Id &&
                                                                                         p.UserId == postLike.UserId, cancellationToken);

        return result;
    }
}
