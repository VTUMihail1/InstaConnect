using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(p => p.Id == entity.Id.Id.Id &&
                                                                                       p.CommentId == entity.Id.CommentId &&
                                                                                       p.UserId == entity.UserId.Id &&
                                                                                       p.Content == entity.Content &&
                                                                                       p.CreatedAtUtc == entity.CreatedAtUtc &&
                                                                                       p.UpdatedAtUtc == entity.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedUpdatedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(p => p.Id == entity.Id.Id.Id &&
                                                                                       p.CommentId == entity.Id.CommentId &&
                                                                                       p.UserId == entity.UserId.Id &&
                                                                                       p.Content == entity.Content &&
                                                                                       p.UpdatedAtUtc == entity.UpdatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostComment entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(p => p.Id == entity.Id.Id.Id &&
                                                                                       p.CommentId == entity.Id.CommentId, cancellationToken);
    }
}
