using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
    public static async Task ShouldHavePublishedAddedAsync(
        this IEventHarness eventHarness,
        PostCommentLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(p => p.Id == entity.Id.CommentId.Id.Id &&
                                                                                           p.CommentId == entity.Id.CommentId.CommentId &&
                                                                                           p.UserId == entity.Id.UserId.Id &&
                                                                                           p.CreatedAtUtc == entity.CreatedAtUtc, cancellationToken);
    }

    public static async Task ShouldHavePublishedDeletedAsync(
        this IEventHarness eventHarness,
        PostCommentLike entity,
        CancellationToken cancellationToken)
    {
        await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(p => p.Id == entity.Id.CommentId.Id.Id &&
                                                                                           p.CommentId == entity.Id.CommentId.CommentId &&
                                                                                           p.UserId == entity.Id.UserId.Id, cancellationToken);
    }
}
