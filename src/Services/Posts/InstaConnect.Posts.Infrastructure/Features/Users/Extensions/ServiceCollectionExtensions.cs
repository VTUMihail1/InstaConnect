using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Users.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.Posts);
            cm.UnmapMember(c => c.PostLikes);
            cm.UnmapMember(c => c.PostComments);
            cm.UnmapMember(c => c.PostCommentLikes);
        });

        return serviceCollection;
    }
}
