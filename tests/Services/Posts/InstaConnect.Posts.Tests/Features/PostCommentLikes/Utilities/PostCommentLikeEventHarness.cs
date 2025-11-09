using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEventHarness
{
    public static async Task<bool> HasPublishPostCommentLikeAddedEventAsync(
        this IEventHarness eventHarness,
        PostCommentLike postCommentLike,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentLikeAddedEventRequest>(p => p.Id == postCommentLike.Id &&
                                                                                   p.CommentId == postCommentLike.CommentId &&
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
        var result = await eventHarness.PublishedAsync<PostCommentLikeDeletedEventRequest>(p => p.Id == postCommentLike.Id &&
                                                                                         p.CommentId == postCommentLike.CommentId &&
                                                                                         p.UserId == postCommentLike.UserId, cancellationToken);

        return result;
    }
}
