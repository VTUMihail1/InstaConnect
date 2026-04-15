using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatMongoCollectionExtensions
{
    extension(IMongoCollection<Chat> collection)
    {
        public async Task DeleteAsync(
            IClientSessionHandle? session,
            Chat entity,
            CancellationToken cancellationToken)
        {
            await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
        }
    }
}
