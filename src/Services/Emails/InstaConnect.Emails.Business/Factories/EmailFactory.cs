using System.Net.Mail;
using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Emails.Business.Factories;

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
        ;
    }
}
