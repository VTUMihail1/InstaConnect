using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
