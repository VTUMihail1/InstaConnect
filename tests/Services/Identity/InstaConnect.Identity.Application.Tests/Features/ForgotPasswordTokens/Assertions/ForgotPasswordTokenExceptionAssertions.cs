using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenNotFoundExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
			VerifyForgotPasswordTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowForgotPasswordTokenExpiredExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}
	}
}
