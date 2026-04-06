using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedPostAddedAsync(
            Post post,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostAddedEventRequest>(
                p => p.Matches(post),
                cancellationToken);
        }

        public async Task ShouldHavePublishedPostUpdatedAsync(
            Post post,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostUpdatedEventRequest>(
                p => p.Matches(post),
                cancellationToken);
        }

        public async Task ShouldHavePublishedPostDeletedAsync(
            Post post,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<PostDeletedEventRequest>(
                p => p.Matches(post),
                cancellationToken);
        }
    }
}
