using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
	extension(IEmailConfirmationTokenCommandService service)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				r => r.Name,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
				r => r.Name,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}
	}
}
