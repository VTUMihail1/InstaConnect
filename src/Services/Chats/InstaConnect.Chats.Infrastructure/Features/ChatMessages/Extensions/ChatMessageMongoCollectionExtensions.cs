using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ChatMessageMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<ChatMessage> collection,
        IClientSessionHandle? session,
        ChatMessage entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
    }

    public static async Task DeleteAsync(
        this IMongoCollection<ChatMessage> collection,
        IClientSessionHandle? session,
        ChatMessage entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
