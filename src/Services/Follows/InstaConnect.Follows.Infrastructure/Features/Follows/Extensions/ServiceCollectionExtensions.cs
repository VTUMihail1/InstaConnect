using InstaConnect.Follows.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

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
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMember(c => c.Follower);
            cm.MapMember(c => c.Following);

            cm.MapCreator(c => new Follow(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
