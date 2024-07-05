using System.Net.Mail;

namespace InstaConnect.Emails.Business.Abstract;

public interface IEmailSender
{
    Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken);
}
