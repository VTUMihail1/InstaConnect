using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;
using InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeEventMatcher
{
    public static async Task<bool> HasPublishPostLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeAddedEvent>(p => p.IsSatisfied(postLike), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostLikeDeletedEventAsync(
        this IEventHarness eventHarness,
        PostLike postLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostLikeDeletedEvent>(p => p.IsSatisfied(postLike), cancellationToken);

        return result;
    }
}
