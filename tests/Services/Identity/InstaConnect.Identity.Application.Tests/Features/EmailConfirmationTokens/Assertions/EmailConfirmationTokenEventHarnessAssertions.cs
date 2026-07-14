using InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventHarnessAssertions
{
	extension(IEventHarness eventHarness)
	{
		public async Task ShouldHavePublishedEmailConfirmationTokenAddedAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
				p => p.Matches(emailConfirmationToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenAddedAsync(
			AddEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
				p => p.Matches(request, emailConfirmationToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenAddedAsync(emailConfirmationToken.AddUser(user), cancellationToken);
			}
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(
			AddEmailConfirmationTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenAddedAsync(request, emailConfirmationToken, cancellationToken);
			}
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenDeletedAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
				p => p.Matches(emailConfirmationToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenDeletedAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
				p => p.Matches(request, emailConfirmationToken),
				cancellationToken);
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedAsync(emailConfirmationToken.AddUser(user), cancellationToken);
			}
		}

		public async Task ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedAsync(request, emailConfirmationToken.AddUser(user), cancellationToken);
			}
		}
	}
}
