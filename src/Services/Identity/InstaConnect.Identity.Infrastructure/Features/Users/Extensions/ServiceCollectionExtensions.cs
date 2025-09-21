using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Users.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserSortProperty>(IdentityInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
