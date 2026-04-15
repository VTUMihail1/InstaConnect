using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedForgotPasswordTokenAddedAsync(
            ForgotPasswordToken forgotPasswordToken,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenAddedEventRequest>(
                p => p.Matches(forgotPasswordToken),
                cancellationToken);
        }

        public async Task ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(
            User user,
            CancellationToken cancellationToken)
        {
            foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
            {
                await eventHarness.ShouldHavePublishedForgotPasswordTokenAddedAsync(forgotPasswordToken, cancellationToken);
            }
        }

        public async Task ShouldHavePublishedForgotPasswordTokenDeletedAsync(
            ForgotPasswordToken forgotPasswordToken,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenDeletedEventRequest>(
                p => p.Matches(forgotPasswordToken),
                cancellationToken);
        }

        public async Task ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(
            User user,
            CancellationToken cancellationToken)
        {
            foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
            {
                await eventHarness.ShouldHavePublishedForgotPasswordTokenDeletedAsync(forgotPasswordToken.AddUser(user), cancellationToken);
            }
        }
    }
}
