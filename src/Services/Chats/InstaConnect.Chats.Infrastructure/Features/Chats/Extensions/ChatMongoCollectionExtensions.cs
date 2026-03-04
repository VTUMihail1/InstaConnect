using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatMongoCollectionExtensions
{
    public static async Task DeleteAsync(
        this IMongoCollection<Chat> collection,
        IClientSessionHandle? session,
        Chat entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
