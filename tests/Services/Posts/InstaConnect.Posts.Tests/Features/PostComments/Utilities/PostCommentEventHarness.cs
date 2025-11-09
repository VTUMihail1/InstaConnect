using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEventHarness
{
    public static async Task<bool> HasPublishPostCommentAddedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentAddedEventRequest>(p => p.Id == postComment.Id &&
                                                                                   p.CommentId == postComment.CommentId &&
                                                                                   p.Content == postComment.Content &&
                                                                                   p.UserId == postComment.UserId &&
                                                                                   p.CreatedAt == postComment.CreatedAt &&
                                                                                   p.UpdatedAt == postComment.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentUpdatedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentUpdatedEventRequest>(p => p.Id == postComment.Id &&
                                                                                     p.CommentId == postComment.CommentId &&
                                                                                     p.Content == postComment.Content &&
                                                                                     p.UserId == postComment.UserId &&
                                                                                     p.CreatedAt == postComment.CreatedAt &&
                                                                                     p.UpdatedAt == postComment.UpdatedAt, cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentDeletedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentDeletedEventRequest>(p => p.Id == postComment.Id &&
                                                                                     p.CommentId == postComment.CommentId, cancellationToken);

        return result;
    }
}
