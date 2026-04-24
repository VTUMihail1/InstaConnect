using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
    extension(RefreshToken refreshToken)
    {
        private AccessTokenCommandResponse ToResponse()
        {
            return new(refreshToken.Id.Value, refreshToken.ExpiresAtUtc);
        }

        internal RefreshTokenIdCommandResponse ToIdResponse()
        {
            return new(refreshToken.Id.Id.Id, refreshToken.Id.Value);
        }

        internal SessionTokenCommandResponse ToSessionTokenResponse()
        {
            return new(
                refreshToken.ToIdResponse(),
                refreshToken.ToResponse(),
                refreshToken.ExpiresAtUtc);
        }

        public IssueRefreshTokenCommandResponse ToResponse(IssueRefreshTokenApiRequest request)
        {
            return new(refreshToken.ToSessionTokenResponse());
        }

        public RotateRefreshTokenCommandResponse ToResponse(RotateRefreshTokenApiRequest request)
        {
            return new(refreshToken.ToSessionTokenResponse());
        }
    }

    extension(AccessToken accessToken)
    {
        internal AccessTokenCommandResponse ToResponse()
        {
            return new(accessToken.Value, accessToken.ExpiresAtUtc);
        }
    }
}
