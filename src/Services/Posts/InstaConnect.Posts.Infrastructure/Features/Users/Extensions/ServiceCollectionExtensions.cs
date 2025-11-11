using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.UnmapMember(c => c.Posts);
            cm.UnmapMember(c => c.PostLikes);
            cm.UnmapMember(c => c.PostComments);
            cm.UnmapMember(c => c.PostCommentLikes);
        });

        return serviceCollection;
    }
}
