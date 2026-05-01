using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ChatMessageMongoCollectionExtensions
{
	extension(IMongoCollection<ChatMessage> collection)
	{
		public async Task UpdateAsync(
			IClientSessionHandle? session,
			ChatMessage entity,
			CancellationToken cancellationToken)
		{
			await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
		}

		public async Task DeleteAsync(
			IClientSessionHandle? session,
			ChatMessage entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}
	}
}
