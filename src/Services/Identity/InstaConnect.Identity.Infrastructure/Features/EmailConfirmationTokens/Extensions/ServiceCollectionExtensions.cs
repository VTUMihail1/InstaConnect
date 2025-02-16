using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;

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

        return serviceCollection;
    }
}
