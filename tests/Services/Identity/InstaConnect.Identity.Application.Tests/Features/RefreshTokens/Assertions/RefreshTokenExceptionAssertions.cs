using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserInvalidDetailsExceptionAsync(
			IssueRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserInvalidDetailsExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
			IssueRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(
				r => r.Name,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserEmailNotConfirmedExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserEmailNotConfirmedExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenNotFoundExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenExpiredExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowRefreshExpiredExceptionAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowRefreshTokenExpiredExceptionAsync(
				r => r.Id,
				r => r.Value,
				request,
				cancellationToken);
		}
	}
}
