using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            User entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUpdatedAsync(
            User entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserUpdatedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            User entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
