using System.Net.Mail;

using InstaConnect.Common.Infrastructure.Features.Emails.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Helpers;

internal class MailMessageFactory : IMailMessageFactory
{
    private readonly EmailOptions _emailOptions;

    public MailMessageFactory(IOptions<EmailOptions> options)
    {
        _emailOptions = options.Value;
    }

    public MailMessage Get(string receiver, string subject, string template)
    {
        return new MailMessage(_emailOptions.Sender, receiver, subject, template);
    }
}
