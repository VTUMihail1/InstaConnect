using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentsSortTermer>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostCommentIncluder>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<PostComment>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.UserId);
            cm.MapMember(c => c.Content);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);
            cm.MapMemberWithoutSerialization(c => c.Post);
            cm.MapMemberWithoutSerialization(c => c.PostCommentLikes);

            cm.MapCreator(c => new PostComment(
                c.Id,
                c.Content,
                c.UserId,
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
