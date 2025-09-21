using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
