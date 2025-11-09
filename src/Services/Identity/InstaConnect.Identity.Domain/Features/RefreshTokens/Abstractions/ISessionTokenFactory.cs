namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface ISessionTokenFactory
{
    public SessionToken Create(
        RefreshToken refreshToken,
        AccessToken accessToken);
}
