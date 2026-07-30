namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IRefreshTokenCommandService service)
	{
		public void SetupIssueCommand(
			IssueRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service
				.IssueAsync(RefreshTokenApplicationMatcher.IsIssueRefreshTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}

		public void SetupRotateCommand(
			RotateRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service
				.RotateAsync(RefreshTokenApplicationMatcher.IsRotateRefreshTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}
	}
}
