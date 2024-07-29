using InstaConnect.Identity.Data.Features.Tokens.Models;
using InstaConnect.Identity.Data.Features.Tokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.Tokens.Abstractions;

public interface ITokenGenerator
{
    Token GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);

    Token GenerateEmailConfirmationToken(CreateAccountTokenModel createAccountTokenModel);

    Token GeneratePasswordResetToken(CreateAccountTokenModel createAccountTokenModel);
}
