using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedPostCommentAddedAsync(
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
                p => p.Matches(postComment),
                cancellationToken);
        }

        public async Task ShouldHavePublishedPostCommentUpdatedAsync(
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
                p => p.Matches(postComment),
                cancellationToken);
        }

        public async Task ShouldHavePublishedPostCommentDeletedAsync(
            PostComment postComment,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
                p => p.Matches(postComment),
                cancellationToken);
        }
    }
}
