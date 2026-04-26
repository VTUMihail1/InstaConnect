using System.Net.Mail;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Abstractions;

public interface IMailMessageFactory
{
    MailMessage Get(string receiver, string subject, string template);
}
