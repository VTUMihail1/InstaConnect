using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

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
