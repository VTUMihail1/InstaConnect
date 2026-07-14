using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedForgotPasswordTokenAddedAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenAddedEventRequest>(
				p => p.Matches(command, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(
			AddForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedForgotPasswordTokenAddedAsync(command, forgotPasswordToken, cancellationToken);
			}
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedAsync(
			VerifyForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenDeletedEventRequest>(
				p => p.Matches(command, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(
			VerifyForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedForgotPasswordTokenDeletedAsync(command, forgotPasswordToken.AddUser(user), cancellationToken);
			}
		}
	}
}
