using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
