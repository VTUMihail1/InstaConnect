using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(IRefreshTokenCommandService service)
	{
		public async Task ShouldThrowUserInvalidDetailsExceptionAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.IssueAsync(command, cancellationToken);

			await func.ShouldThrowUserInvalidDetailsExceptionAsync(
				r => r.Name,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
			IssueRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.IssueAsync(command, cancellationToken);

			await func.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
				r => r.Name,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowUserEmailNotConfirmedExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			DeleteRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync(
			RotateRefreshTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.RotateAsync(command, cancellationToken);

			await func.ShouldThrowRefreshTokenExpiredExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}
	}
}
