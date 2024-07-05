using System.Net.Mail;

namespace InstaConnect.Emails.Business.Abstract;

public interface IEmailFactory
{
    MailMessage GetEmail(string receiver, string subject, string template);
}
