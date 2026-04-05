using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            UserClaim entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserClaimAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            UserClaim entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserClaimDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
