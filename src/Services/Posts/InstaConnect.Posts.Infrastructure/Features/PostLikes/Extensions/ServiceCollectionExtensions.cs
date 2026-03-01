using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostLikesSortTermer>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostLikesForUserSortTermer>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostLikeIncluder>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<PostLike>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);
            cm.MapMemberWithoutSerialization(c => c.Post);

            cm.MapCreator(c => new PostLike(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
