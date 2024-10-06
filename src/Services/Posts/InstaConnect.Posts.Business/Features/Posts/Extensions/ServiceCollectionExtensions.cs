using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
