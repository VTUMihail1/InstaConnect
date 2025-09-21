using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Domain.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddFollowServices();

        serviceCollection
            .AddMapper(FollowDomainReference.Assembly)
            .AddServicesWithMatchingInterfaces(FollowDomainReference.Assembly);

        return serviceCollection;
    }
}
