using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
