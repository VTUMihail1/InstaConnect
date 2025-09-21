using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
