using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMapper
{
    extension(RefreshToken refreshToken)
    {
        internal RefreshTokenIdCommandResponse ToIdResponse()
        {
            return new(refreshToken.Id.Id.Id, refreshToken.Id.Value);
        }

        public IssueRefreshTokenCommandResponse ToResponse(
            IssueRefreshTokenApiRequest request,
            AccessToken accessToken)
        {
            return new(
                refreshToken.ToIdResponse(),
                accessToken.ToResponse(),
                refreshToken.ExpiresAtUtc);
        }

        public RotateRefreshTokenCommandResponse ToResponse(
            RotateRefreshTokenApiRequest request,
            AccessToken accessToken)
        {
            return new(
                refreshToken.ToIdResponse(),
                accessToken.ToResponse(),
                refreshToken.ExpiresAtUtc);
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
