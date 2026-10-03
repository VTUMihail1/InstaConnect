using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
			IssueRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsIssueRefreshTokenCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}

		public void SetupSendAsync(
			RotateRefreshTokenApiRequest request,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(request.IsRotateRefreshTokenCommandRequest(), cancellationToken)
				.ReturnsTaskResponse(refreshToken.ToResponse(request));
		}
	}
}
