using System.Net;
using System.Net.Mail;

using InstaConnect.Emails.Infrastructure.Features.Emails.Models.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddEmailServices(IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<EmailOptions>()
                .BindConfiguration(nameof(EmailOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var emailOptions = configuration
                .GetSection(nameof(EmailOptions))
                .Get<EmailOptions>()!;

            serviceCollection.AddScoped(_ => new SmtpClient()
            {
                Host = emailOptions.SmtpServer,
                Port = emailOptions.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailOptions.Username, emailOptions.Password)
            });

            return serviceCollection;
        }
    }
}
