using InstaConnect.Identity.Business.Features.Accounts.Models;

namespace InstaConnect.Identity.Business.Features.Accounts.Abstractions;

public interface IAccessTokenGenerator
{
    AccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);
}
