using InstaConnect.Identity.Business.Features.Users.Models;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;

public interface IAccessTokenGenerator
{
    AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);
}
