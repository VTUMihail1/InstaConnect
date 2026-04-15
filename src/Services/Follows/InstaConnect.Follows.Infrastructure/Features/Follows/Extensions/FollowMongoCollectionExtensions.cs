using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class FollowMongoCollectionExtensions
{
    extension(IMongoCollection<Follow> collection)
    {
        public async Task UpdateAsync(
            IClientSessionHandle? session,
            Follow entity,
            CancellationToken cancellationToken)
        {
            await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
        }

        public async Task DeleteAsync(
            IClientSessionHandle? session,
            Follow entity,
            CancellationToken cancellationToken)
        {
            await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
        }
    }
}
