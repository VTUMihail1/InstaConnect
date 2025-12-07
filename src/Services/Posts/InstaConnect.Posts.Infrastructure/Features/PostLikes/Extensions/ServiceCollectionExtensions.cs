using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostLikeSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostLikeIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<PostLike>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMember(c => c.User);

            cm.MapCreator(c => new PostLike(
                new(
                    new(c.Id.Id.Id),
                    new(c.Id.UserId.Id)),
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
