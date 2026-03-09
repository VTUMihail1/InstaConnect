using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            EmailConfirmationToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            EmailConfirmationToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
