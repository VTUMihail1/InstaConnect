using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<EmailConfirmationOptions>()
            .BindConfiguration(nameof(EmailConfirmationOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddTransient<IEmailConfirmationTokenWriteRepository, EmailConfirmationTokenWriteRepository>()
            .AddTransient<IEmailConfirmationTokenPublisher, EmailConfirmationTokenPublisher>()
            .AddScoped<IEmailConfirmationTokenGenerator, EmailConfirmationTokenGenerator>();

        return serviceCollection;
    }
}
