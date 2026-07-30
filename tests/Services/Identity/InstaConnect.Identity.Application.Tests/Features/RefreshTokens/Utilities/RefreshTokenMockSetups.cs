namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IRefreshTokenCommandService service)
	{
		public void SetupIssueAsync(
			IssueRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.IssueAsync(RefreshTokenApplicationMatcher.IsIssueRefreshTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}

		public void SetupRotateAsync(
			RotateRefreshTokenCommandRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			service
				.ClearCalls()
				.RotateAsync(RefreshTokenApplicationMatcher.IsRotateRefreshTokenCommand(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}
	}
}
