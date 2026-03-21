using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            ForgotPasswordToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            ForgotPasswordToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }
    }
}
