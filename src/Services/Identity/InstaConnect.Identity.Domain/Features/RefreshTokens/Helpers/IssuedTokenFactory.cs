using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

internal class IssuedTokenFactory : ISessionTokenFactory
{
    public SessionToken Create(RefreshToken refreshToken, AccessToken accessToken)
    {
        var issuedTokens = new SessionToken(
            refreshToken,
            accessToken);

        return issuedTokens;
    }
}
