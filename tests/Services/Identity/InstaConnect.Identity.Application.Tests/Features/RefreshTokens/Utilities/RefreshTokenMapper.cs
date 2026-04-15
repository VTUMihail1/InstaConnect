namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
    extension(RefreshToken refreshToken)
    {
        private AccessToken ToAccessToken()
        {
            return new(refreshToken.Id.Value, refreshToken.ExpiresAtUtc);
        }
        internal RefreshTokenId ToIdResponse()
        {
            return refreshToken.Id;
        }

        internal SessionToken ToSessionTokenResponse()
        {
            return new(refreshToken.Id, refreshToken.ToAccessToken(), refreshToken.ExpiresAtUtc);
        }

        public SessionToken ToResponse(
            IssueRefreshTokenCommandRequest request)
        {
            return refreshToken.ToSessionTokenResponse();
        }

        public SessionToken ToResponse(
            RotateRefreshTokenCommandRequest request)
        {
            return refreshToken.ToSessionTokenResponse();
        }
    }
}
