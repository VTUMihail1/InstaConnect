using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            PostCommentLike entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentLikeAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            PostCommentLike entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostCommentLikeDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
