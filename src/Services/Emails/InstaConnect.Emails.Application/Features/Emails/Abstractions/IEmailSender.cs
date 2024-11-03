using System.Net.Mail;

namespace InstaConnect.Emails.Business.Features.Emails.Abstractions;

public interface IEmailSender
{
    Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken);
}
