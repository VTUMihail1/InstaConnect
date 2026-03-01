using InstaConnect.Follows.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddFollowServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IFollowsForFollowerSortTermer>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowsForFollowingSortTermer>(FollowInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IFollowIncluder>(FollowInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<Follow>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.Follower);
            cm.MapMemberWithoutSerialization(c => c.Following);

            cm.MapCreator(c => new Follow(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
