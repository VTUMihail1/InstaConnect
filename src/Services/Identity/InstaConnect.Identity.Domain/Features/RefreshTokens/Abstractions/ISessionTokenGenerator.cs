namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
public interface ISessionTokenGenerator
{
    SessionToken Generate(RefreshToken refreshToken);
}
