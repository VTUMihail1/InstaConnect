using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Application.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
