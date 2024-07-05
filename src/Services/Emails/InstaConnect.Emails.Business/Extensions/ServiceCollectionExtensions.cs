using System.Net;
using System.Net.Mail;
using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Factories;
using InstaConnect.Emails.Business.Helpers;
using InstaConnect.Emails.Business.Models.Options;
using InstaConnect.Emails.Business.Profiles;
using InstaConnect.Shared.Business.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Emails.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddOptions<EmailOptions>()
            .BindConfiguration(nameof(EmailOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var emailOptions = configuration
            .GetSection(nameof(EmailOptions))
            .Get<EmailOptions>()!;

        serviceCollection
            .AddOptions<EndpointOptions>()
            .BindConfiguration(nameof(EndpointOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddAutoMapper(currentAssembly)
            .AddMessageBroker(configuration, currentAssembly);

        serviceCollection
            .AddScoped<IEmailEndpointHandler, EmailEndpointHandler>()
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IEmailFactory, EmailFactory>()
            .AddScoped<IEmailHandler, EmailHandler>()
            .AddAutoMapper(typeof(EmailsBusinessProfile));

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
