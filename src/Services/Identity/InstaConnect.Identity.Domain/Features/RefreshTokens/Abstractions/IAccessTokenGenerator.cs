namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IAccessTokenGenerator
{
    AccessToken Generate(User user);
}
