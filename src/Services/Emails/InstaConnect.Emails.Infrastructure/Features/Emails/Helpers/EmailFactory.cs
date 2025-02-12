using System.Net.Mail;
using InstaConnect.Emails.Application.Features.Emails.Abstractions;
using InstaConnect.Emails.Infrastructure.Features.Emails.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Helpers;

internal class EmailFactory : IEmailFactory
{
    private readonly EmailOptions _emailOptions;

    public EmailFactory(IOptions<EmailOptions> options)
    {
        _emailOptions = options.Value;
    }

    public MailMessage GetEmail(string receiver, string subject, string template)
    {
        return new MailMessage(_emailOptions.Sender, receiver, subject, template);
    }
}
