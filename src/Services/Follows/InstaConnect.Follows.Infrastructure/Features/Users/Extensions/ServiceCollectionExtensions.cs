using InstaConnect.Follows.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(FollowInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id);

            cm.UnmapMember(c => c.FollowerFollows);
            cm.UnmapMember(c => c.FollowingFollows);
        });

        return serviceCollection;
    }
}
