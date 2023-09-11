using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface ITokenHandler
    {
        TokenAddDTO GenerateAccessToken(string userId);

        TokenAddDTO GenerateEmailConfirmationToken(string value);

        TokenAddDTO GenerateForgotPasswordToken(string value);
    }
}