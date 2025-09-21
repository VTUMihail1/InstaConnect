using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
