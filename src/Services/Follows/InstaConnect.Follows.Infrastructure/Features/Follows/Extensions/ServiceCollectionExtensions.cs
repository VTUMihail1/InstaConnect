using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IFollowByFollowerSortProperty>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowByFollowingSortProperty>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowIncludeProperty>(FollowInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<Follow>(cm =>
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
