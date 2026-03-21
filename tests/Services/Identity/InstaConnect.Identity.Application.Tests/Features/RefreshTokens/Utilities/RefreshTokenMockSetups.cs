namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
    extension(IRefreshTokenCommandService service)
    {
        public void SetupIssueCommand(
            IssueRefreshTokenCommandRequest request,
            RefreshToken refreshToken,
            AccessToken accessToken,
            CancellationToken cancellationToken)
        {
            service
                .IssueAsync(RefreshTokenMatcher.IsIssueRefreshTokenCommand(request), cancellationToken)
                .ReturnsResponse(refreshToken.ToResponse(request, accessToken));
        }

        public void SetupRotateCommand(
            RotateRefreshTokenCommandRequest request,
            RefreshToken refreshToken,
            AccessToken accessToken,
            CancellationToken cancellationToken)
        {
            service
                .RotateAsync(RefreshTokenMatcher.IsRotateRefreshTokenCommand(request), cancellationToken)
                .ReturnsResponse(refreshToken.ToResponse(request, accessToken));
        }
    }
}
