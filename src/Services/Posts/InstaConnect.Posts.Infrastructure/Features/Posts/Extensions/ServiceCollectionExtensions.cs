using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostsSortTermer>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostIncluder>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<Post>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.UserId);
            cm.MapMember(c => c.Title);
            cm.MapMember(c => c.Content);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);
            cm.MapMemberWithoutSerialization(c => c.PostLikes);
            cm.MapMemberWithoutSerialization(c => c.PostComments);

            cm.MapCreator(c => new Post(
                c.Id,
                c.Title,
                c.Content,
                c.UserId,
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
