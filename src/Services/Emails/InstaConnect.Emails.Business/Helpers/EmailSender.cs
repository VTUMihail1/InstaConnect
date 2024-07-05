using InstaConnect.Emails.Business.Abstract;
using System.Net.Mail;

namespace InstaConnect.Emails.Business.Helpers;

internal class EmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;

    public EmailSender(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken)
    {
        await _smtpClient.SendMailAsync(mailMessage, cancellationToken);
    }
}
