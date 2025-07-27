using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
