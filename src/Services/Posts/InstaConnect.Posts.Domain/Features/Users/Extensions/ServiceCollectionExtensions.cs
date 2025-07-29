using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Domain.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
