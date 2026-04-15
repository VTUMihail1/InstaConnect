using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

internal static class UserMongoCollectionExtensions
{
    extension(IMongoCollection<User> collection)
    {
        public async Task UpdateAsync(
            IClientSessionHandle? session,
            User entity,
            CancellationToken cancellationToken)
        {
            await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
        }

        public async Task DeleteAsync(
            IClientSessionHandle? session,
            User entity,
            CancellationToken cancellationToken)
        {
            await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
        }
    }
}
