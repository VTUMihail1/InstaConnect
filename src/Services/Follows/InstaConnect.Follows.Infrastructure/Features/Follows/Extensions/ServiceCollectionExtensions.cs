using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IFollowByFollowerSortProperty>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowByFollowingSortProperty>(FollowInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
