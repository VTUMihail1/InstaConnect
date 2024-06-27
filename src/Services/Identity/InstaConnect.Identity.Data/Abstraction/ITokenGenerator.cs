using InstaConnect.Identity.Data.Models;
using InstaConnect.Identity.Data.Models.Entities;

namespace InstaConnect.Identity.Data.Abstraction;

public interface ITokenGenerator
{
    Token GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);

    Token GenerateEmailConfirmationToken(CreateAccountTokenModel createAccountTokenModel);

    Token GeneratePasswordResetToken(CreateAccountTokenModel createAccountTokenModel);
}
