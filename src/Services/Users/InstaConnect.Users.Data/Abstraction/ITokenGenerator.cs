using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Models;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction;

public interface ITokenGenerator
{
    Token GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);

    Token GenerateEmailConfirmationToken(CreateAccountTokenModel createAccountTokenModel);

    Token GeneratePasswordResetToken(CreateAccountTokenModel createAccountTokenModel);
}
