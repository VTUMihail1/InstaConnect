namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
    extension(RefreshToken refreshToken)
    {
        internal RefreshTokenId ToIdResponse()
        {
            return refreshToken.Id;
        }

        internal SessionToken ToSessionTokenResponse(AccessToken accessToken)
        {
            return new(refreshToken.Id, accessToken, refreshToken.ExpiresAtUtc);
        }

        public SessionToken ToResponse(
            IssueRefreshTokenCommandRequest request,
            AccessToken accessToken)
        {
            return refreshToken.ToSessionTokenResponse(accessToken);
        }

        public SessionToken ToResponse(
            RotateRefreshTokenCommandRequest request,
            AccessToken accessToken)
        {
            return refreshToken.ToSessionTokenResponse(accessToken);
        }
    }
}
