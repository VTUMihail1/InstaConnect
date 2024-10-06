using System.Net.Mail;

namespace InstaConnect.Emails.Business.Features.Emails.Abstractions;

public interface IEmailFactory
{
    MailMessage GetEmail(string receiver, string subject, string template);
}
