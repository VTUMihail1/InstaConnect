using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeEventHarness
{
    public static async Task<bool> HasPublishPostLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeAddedEventRequest>(p => p.Id == postLike.Id &&
                                                                                p.LikeId == postLike.LikeId &&
                                                                                p.UserId == postLike.UserId &&
                                                                                p.CreatedAt == postLike.CreatedAt &&
                                                                                p.UpdatedAt == postLike.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostLikeDeletedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeDeletedEventRequest>(p => p.Id == postLike.Id &&
                                                                                  p.LikeId == postLike.LikeId, cancellationToken);

        return result;
    }
}
