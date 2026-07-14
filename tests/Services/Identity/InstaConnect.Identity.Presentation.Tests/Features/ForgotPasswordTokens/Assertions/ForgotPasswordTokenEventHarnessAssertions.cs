using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedForgotPasswordTokenAddedAsync(
			AddForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenAddedEventRequest>(
				p => p.Matches(request, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenAddedRangeAsync(
			AddForgotPasswordTokenApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var forgotPasswordToken in user.ForgotPasswordTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedForgotPasswordTokenAddedAsync(request, forgotPasswordToken, cancellationToken);
			}
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedAsync(
			VerifyForgotPasswordTokenApiRequest request,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<ForgotPasswordTokenDeletedEventRequest>(
				p => p.Matches(request, forgotPasswordToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedForgotPasswordTokenDeletedRangeAsync(
			VerifyForgotPasswordTokenApiRequest request,
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
