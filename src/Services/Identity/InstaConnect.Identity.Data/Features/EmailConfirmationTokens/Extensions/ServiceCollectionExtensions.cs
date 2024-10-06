using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Extensions;

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
            .AddTransient<IEmailConfirmationTokenFactory, EmailConfirmationTokenFactory>();

        return serviceCollection;
    }
}
