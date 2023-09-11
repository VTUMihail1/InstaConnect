using InstaConnect.Business.Models.DTOs.Account;

namespace InstaConnect.Business.Abstraction.Factories
{
    public interface IEmailFactory
    {
        AccountSendEmailDTO GetEmailVerificationDTO(string email, string template);

        AccountSendEmailDTO GetPasswordResetDTO(string email, string template);
    }
}