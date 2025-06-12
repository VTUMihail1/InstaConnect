using InstaConnect.Posts.Infrastructure.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostSortProperty>(PostInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
