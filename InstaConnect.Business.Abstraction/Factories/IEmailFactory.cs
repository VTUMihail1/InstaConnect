using InstaConnect.Business.Models.DTOs.Account;

namespace InstaConnect.Business.Abstraction.Factories
{
    public interface IEmailFactory
    {
        AccountSendEmailDTO GetEmailVerificationDTO(string email, string domain, string userId, string token);

        AccountSendEmailDTO GetPasswordResetDTO(string email, string domain, string userId, string token);
    }
}