using InstaConnect.Posts.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddPostCommentServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IPostCommentSortProperty>(PostInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IPostCommentIncludeProperty>(PostInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<PostComment>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.UserId);
            cm.MapMember(c => c.Content);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMember(c => c.User);
            cm.MapMember(c => c.Likes);

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
