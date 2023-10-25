using InstaConnect.Business.Models.DTOs.Account;
using SendGrid.Helpers.Mail;

namespace InstaConnect.Business.Abstraction.Factories
{
    public interface IEmailFactory
    {
        SendGridMessage GetEmail(string receiver, string subject, string plaintText, string template);
    }
}