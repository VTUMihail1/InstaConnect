using InstaConnect.Posts.Domain.Features.PostLikes.Abstract;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
