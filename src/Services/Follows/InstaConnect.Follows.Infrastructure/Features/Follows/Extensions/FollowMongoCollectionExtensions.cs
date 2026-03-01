using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class FollowMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<Follow> collection,
        IClientSessionHandle? session,
        Follow entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteAsync(
        this IMongoCollection<Follow> collection,
        IClientSessionHandle? session,
        Follow entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
