using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNameNotFoundExceptionAsync(
			AddEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameNotFoundExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
			AddEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailAlreadyConfirmedExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenNotFoundExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
			VerifyEmailConfirmationTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowEmailConfirmationTokenExpiredExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}
	}
}
