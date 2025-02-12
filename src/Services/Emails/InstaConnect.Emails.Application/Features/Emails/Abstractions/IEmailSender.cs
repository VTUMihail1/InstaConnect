using System.Net.Mail;

namespace InstaConnect.Emails.Application.Features.Emails.Abstractions;

public interface IEmailSender
{
    Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken);
}
