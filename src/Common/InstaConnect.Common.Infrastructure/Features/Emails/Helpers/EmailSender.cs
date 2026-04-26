using System.Net.Mail;

using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Infrastructure.Features.Emails.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Helpers;

internal class EmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;
    private readonly IMailMessageFactory _mailMessageFactory;

    public EmailSender(SmtpClient smtpClient, IMailMessageFactory mailMessageFactory)
    {
        _smtpClient = smtpClient;
        _mailMessageFactory = mailMessageFactory;
    }

    public async Task SendAsync(SendEmailRequest request, CancellationToken cancellationToken)
    {
        var message = _mailMessageFactory.Get(request.Receiver, request.Subject, request.Template);

        await _smtpClient.SendMailAsync(message, cancellationToken);
    }
}
