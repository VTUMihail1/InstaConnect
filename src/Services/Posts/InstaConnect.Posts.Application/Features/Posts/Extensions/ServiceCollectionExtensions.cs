using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
