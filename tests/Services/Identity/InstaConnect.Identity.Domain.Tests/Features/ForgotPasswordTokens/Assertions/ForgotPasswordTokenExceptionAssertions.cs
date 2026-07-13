using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(IForgotPasswordTokenCommandService service)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(command, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				r => r.Name,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			var func = () => service.VerifyAsync(command, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
				r => r.Id,
				command,
				cancellationToken);
		}
	}
}
