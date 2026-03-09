using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            Post entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUpdatedAsync(
            Post entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            Post entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
