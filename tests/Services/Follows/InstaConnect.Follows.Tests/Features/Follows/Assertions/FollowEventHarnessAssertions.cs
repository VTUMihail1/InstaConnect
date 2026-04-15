using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedFollowAddedAsync(
            Follow follow,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<FollowAddedEventRequest>(
                p => p.Matches(follow),
                cancellationToken);
        }

        public async Task ShouldHavePublishedFollowDeletedAsync(
            Follow follow,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<FollowDeletedEventRequest>(
                p => p.Matches(follow),
                cancellationToken);
        }
    }
}
