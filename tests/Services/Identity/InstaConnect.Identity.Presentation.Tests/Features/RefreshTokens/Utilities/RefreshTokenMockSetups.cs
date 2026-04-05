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
                .SendAsync(RefreshTokenMatcher.IsIssueRefreshTokenCommandRequest(request), cancellationToken)
                .ReturnsResponse(refreshToken.ToResponse(request));
        }

        public void SetupRotateCommandRequest(
            RotateRefreshTokenApiRequest request,
            RefreshToken refreshToken,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(RefreshTokenMatcher.IsRotateRefreshTokenCommandRequest(request), cancellationToken)
                .ReturnsResponse(refreshToken.ToResponse(request));
        }
    }
}
