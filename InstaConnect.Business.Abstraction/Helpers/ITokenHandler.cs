using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface ITokenHandler
    {
        TokenAddDTO GenerateAccessToken(TokenGenerateDTO tokenGenerateDTO);

        TokenAddDTO GenerateEmailConfirmationToken(string token);

        TokenAddDTO GenerateForgotPasswordToken(string token);
    }
}