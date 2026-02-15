using System.Runtime.CompilerServices;

using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentLikeServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentLikesSortTermer>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostCommentLikeIncluder>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<PostCommentLike>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);
            cm.MapMemberWithoutSerialization(c => c.PostComment);

            cm.MapCreator(c => new PostCommentLike(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}

