using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

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
