using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

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

            cm.MapIdMember(c => c.Id)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.User);
            cm.UnmapMember(c => c.Likes);
            cm.UnmapMember(c => c.Comments);
        });

        return serviceCollection;
    }
}
