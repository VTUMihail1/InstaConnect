namespace InstaConnect.Identity.Application.Features.Users.Abstractions;

public interface IAccessTokenGenerator
{
    AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);
}
