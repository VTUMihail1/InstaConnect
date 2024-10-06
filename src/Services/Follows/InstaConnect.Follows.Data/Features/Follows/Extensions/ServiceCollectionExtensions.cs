using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IFollowReadRepository, FollowReadRepository>()
            .AddScoped<IFollowWriteRepository, FollowWriteRepository>();

        return serviceCollection;
    }
}
