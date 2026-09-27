using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMockAssertions
{
	extension(IRefreshTokenCommandService refreshTokenService)
	{
		public async Task ShouldReceiveOneIssueAsync(
		IssueRefreshTokenCommandRequest request,
		CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().IssueAsync(request.IsIssueRefreshTokenCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneRotateAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().RotateAsync(request.IsRotateRefreshTokenCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().DeleteAsync(request.IsDeleteRefreshTokenCommand(), cancellationToken);
		}
	}
}
