using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface ISessionTokenFactory
{
    public SessionToken Create(
        RefreshToken refreshToken,
        AccessToken accessToken);
}
