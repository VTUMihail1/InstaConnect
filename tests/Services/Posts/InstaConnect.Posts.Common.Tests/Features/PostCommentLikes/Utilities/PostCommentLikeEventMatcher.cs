using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;
using InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEventMatcher
{
    public static async Task<bool> HasPublishPostCommentLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentLikeAddedEvent>(p => p.IsSatisfied(postCommentLike), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentLikeDeletedEventAsync(
        this IEventHarness eventHarness,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentLikeDeletedEvent>(p => p.IsSatisfied(postCommentLike), cancellationToken);

        return result;
    }
}
