using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Assertions;

public static class UserEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedUserAddedAsync(
            User user,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserAddedEventRequest>(
                p => p.Matches(user),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUserUpdatedAsync(
            User user,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserUpdatedEventRequest>(
                p => p.Matches(user),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUserDeletedAsync(
            User user,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserDeletedEventRequest>(
                p => p.Matches(user),
                cancellationToken);
        }
    }
}
