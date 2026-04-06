using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedUserClaimAddedAsync(
            UserClaim userClaim,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserClaimAddedEventRequest>(
                p => p.Matches(userClaim),
                cancellationToken);
        }

        public async Task ShouldHavePublishedUserClaimDeletedAsync(
            UserClaim userClaim,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<UserClaimDeletedEventRequest>(
                p => p.Matches(userClaim),
                cancellationToken);
        }
    }
}
