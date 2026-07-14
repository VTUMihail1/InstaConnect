using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

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
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
				p => p.Matches(command, emailConfirmationToken),
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
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenAddedAsync(command, emailConfirmationToken, cancellationToken);
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
			VerifyEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
				p => p.Matches(command, emailConfirmationToken),
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
			VerifyEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedAsync(command, emailConfirmationToken.AddUser(user), cancellationToken);
			}
		}

		public async Task ShouldHaveNotPublishedEmailConfirmationTokenDeletedAsync(
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventHarness.ShouldHaveNotPublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
				p => p.Matches(emailConfirmationToken),
				cancellationToken);
		}

		public async Task ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(
			User user,
			CancellationToken cancellationToken)
		{
			foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
			{
				await eventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedAsync(emailConfirmationToken, cancellationToken);
			}
		}
	}
}
