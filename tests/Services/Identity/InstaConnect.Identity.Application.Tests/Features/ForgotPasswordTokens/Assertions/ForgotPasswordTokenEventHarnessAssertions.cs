using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedForgotPasswordTokenAddedAsync(
			AddForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenAddedEventRequest>(
				p => p.Matches(request, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(
			AddForgotPasswordTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedForgotPasswordTokenAddedAsync(request, forgotPasswordToken, cancellationToken);
			}
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenDeletedEventRequest>(
				p => p.Matches(request, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedForgotPasswordTokenDeletedAsync(request, forgotPasswordToken.AddUser(user), cancellationToken);
			}
		}
	}
}
