using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
        PostLike entity,
        CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostLikeAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            PostLike entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostLikeDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
