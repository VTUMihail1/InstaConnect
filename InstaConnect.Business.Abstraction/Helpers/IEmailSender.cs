using InstaConnect.Business.Models.DTOs.Account;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IEmailSender
    {
        Task<Response> SendEmailAsync(SendGridMessage sendGridMessage);
    }
}