using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPostReadRepository, PostReadRepository>()
            .AddScoped<IPostWriteRepository, PostWriteRepository>();

        return serviceCollection;
    }
}
