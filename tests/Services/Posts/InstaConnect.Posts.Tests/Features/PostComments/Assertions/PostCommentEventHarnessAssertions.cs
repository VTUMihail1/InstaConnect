using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
        PostComment entity,
        CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUpdatedAsync(
            PostComment entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentUpdatedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            PostComment entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
