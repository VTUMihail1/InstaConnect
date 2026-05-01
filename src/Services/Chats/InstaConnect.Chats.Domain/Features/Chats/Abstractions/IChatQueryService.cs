namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatQueryService
{
	public Task<ChatCollectionResponse> GetAllAsync(GetAllChatsQuery query, CancellationToken cancellationToken);

	public Task<ChatResponse> GetByIdAsync(GetChatByIdQuery query, CancellationToken cancellationToken);
}
