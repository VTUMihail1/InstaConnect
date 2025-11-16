using InstaConnect.Follows.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IFollowByFollowerSortProperty>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowByFollowingSortProperty>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowIncludeProperty>(FollowInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<Follow>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.FollowerId, c.FollowingId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.Follower);
            cm.UnmapMember(c => c.Following);
        });

        return serviceCollection;
    }
}
