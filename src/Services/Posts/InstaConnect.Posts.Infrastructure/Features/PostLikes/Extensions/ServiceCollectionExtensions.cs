using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Extensions;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostLikeSortProperty>(PostInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
