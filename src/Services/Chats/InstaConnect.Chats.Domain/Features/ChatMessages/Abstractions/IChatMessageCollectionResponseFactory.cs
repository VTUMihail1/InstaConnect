namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageCollectionResponseFactory
{
	public ChatMessageCollectionResponse Create(ChatResponse chat, ICollection<ChatMessageResponse> chatMessages, long totalCount, ChatMessagesPaginationQuery pagination);
}
