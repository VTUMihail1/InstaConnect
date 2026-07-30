using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupIssueCommandRequest(
			IssueRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(RefreshTokenPresentationMatcher.IsIssueRefreshTokenCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}

		public void SetupRotateCommandRequest(
			RotateRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(RefreshTokenPresentationMatcher.IsRotateRefreshTokenCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}
	}
}
