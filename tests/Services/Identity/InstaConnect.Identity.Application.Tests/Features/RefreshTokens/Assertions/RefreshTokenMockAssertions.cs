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
			await refreshTokenService.ShouldHaveReceivedOne().IssueAsync(RefreshTokenMatcher.IsIssueRefreshTokenCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneRotateAsync(
			RotateRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().RotateAsync(RefreshTokenMatcher.IsRotateRefreshTokenCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteCurrentRefreshTokenCommandRequest request,
			CancellationToken cancellationToken)
		{
			await refreshTokenService.ShouldHaveReceivedOne().DeleteAsync(RefreshTokenMatcher.IsDeleteRefreshTokenCommand(request), cancellationToken);
		}
	}
}
