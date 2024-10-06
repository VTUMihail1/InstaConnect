using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPostLikeReadRepository, PostLikeReadRepository>()
            .AddScoped<IPostLikeWriteRepository, PostLikeWriteRepository>();

        return serviceCollection;
    }
}
