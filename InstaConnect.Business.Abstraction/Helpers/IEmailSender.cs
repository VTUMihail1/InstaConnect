using InstaConnect.Business.Models.DTOs.Account;

namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(AccountSendEmailDTO accountSendEmailDTO);
    }
}