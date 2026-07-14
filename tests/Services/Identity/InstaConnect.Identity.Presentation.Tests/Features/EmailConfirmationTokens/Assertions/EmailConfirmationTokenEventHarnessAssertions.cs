using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

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
			AddEmailConfirmationTokenApiRequest request,
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
			AddEmailConfirmationTokenApiRequest request,
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
			VerifyEmailConfirmationTokenApiRequest request,
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
			VerifyEmailConfirmationTokenApiRequest request,
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
