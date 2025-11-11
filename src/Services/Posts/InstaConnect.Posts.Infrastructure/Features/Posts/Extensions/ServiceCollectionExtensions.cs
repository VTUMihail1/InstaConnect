using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<Post>(cm =>
        {
            cm.AutoMap();

            cm.UnmapMember(c => c.User);
            cm.UnmapMember(c => c.Likes);
            cm.UnmapMember(c => c.Comments);
        });

        return serviceCollection;
    }
}
