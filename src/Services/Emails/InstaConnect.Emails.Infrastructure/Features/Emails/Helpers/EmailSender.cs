﻿using System.Net.Mail;

using InstaConnect.Emails.Application.Features.Emails.Abstractions;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Helpers;

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
