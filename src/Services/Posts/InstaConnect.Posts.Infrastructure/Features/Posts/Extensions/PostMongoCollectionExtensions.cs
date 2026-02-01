using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<Post> collection,
        IClientSessionHandle? session,
        Post entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteAsync(
        this IMongoCollection<Post> collection,
        IClientSessionHandle? session,
        Post entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
