using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEventHarness
{
    public static async Task<bool> HasPublishPostCommentLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentLikeAddedEvent>(p => p.Id == postCommentLike.Id &&
                                                                                   p.CommentId == postCommentLike.CommentId &&
                                                                                   p.CommentLikeId == postCommentLike.CommentLikeId &&
                                                                                   p.UserId == postCommentLike.UserId &&
                                                                                   p.CreatedAt == postCommentLike.CreatedAt &&
                                                                                   p.UpdatedAt == postCommentLike.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentLikeDeletedEventAsync(
        this IEventHarness eventHarness,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentLikeDeletedEvent>(p => p.Id == postCommentLike.Id &&
                                                                                         p.CommentId == postCommentLike.CommentId &&
                                                                                         p.CommentLikeId == postCommentLike.CommentLikeId, cancellationToken);

        return result;
    }
}
