using System.Net;
using System.Net.Mail;

using InstaConnect.Common.Domain.Features.Emails.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Emails.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Emails.Helpers;
using InstaConnect.Common.Infrastructure.Features.Emails.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddEmailSender(IConfiguration configuration)
        {
            serviceCollection.AddValidatedOptions<EmailOptions>(EmailOptions.SectionName);

            var options = configuration.GetOptions<EmailOptions>(EmailOptions.SectionName);

            serviceCollection.AddScoped(_ => new SmtpClient()
            {
                Host = options.SmtpServer,
                Port = options.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(options.Username, options.Password)
            });

            serviceCollection.AddScoped<IEmailSender, EmailSender>();
            serviceCollection.AddScoped<IMailMessageFactory, MailMessageFactory>();

            return serviceCollection;
        }
    }
}
