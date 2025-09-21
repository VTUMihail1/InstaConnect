using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddRefreshTokenServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
