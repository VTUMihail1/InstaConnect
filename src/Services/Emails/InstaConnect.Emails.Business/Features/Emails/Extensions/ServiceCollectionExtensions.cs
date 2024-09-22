using System.Net;
using System.Net.Mail;
using InstaConnect.Emails.Business.Features.Emails.Abstractions;
using InstaConnect.Emails.Business.Features.Emails.Helpers;
using InstaConnect.Emails.Business.Features.Emails.Models.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Business.Features.Emails.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<EmailOptions>()
            .BindConfiguration(nameof(EmailOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var emailOptions = configuration
            .GetSection(nameof(EmailOptions))
            .Get<EmailOptions>()!;

        serviceCollection
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IEmailFactory, EmailFactory>();

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
