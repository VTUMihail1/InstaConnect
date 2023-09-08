using DocConnect.Business.Models.DTOs.Token;

namespace DocConnect.Business.Helpers
{
    public interface ITokenHandler
    {
        TokenAddDTO GenerateAccessToken(TokenGenerateDTO tokenGenerateDTO);

        TokenAddDTO GenerateEmailConfirmationToken(TokenGenerateDTO tokenGenerateDTO);

        TokenAddDTO GenerateForgotPasswordToken(TokenGenerateDTO tokenGenerateDTO);
    }
}