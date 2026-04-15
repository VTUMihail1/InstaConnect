namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

internal interface IChatMessageCollectionResponseFactory
{
    ChatMessageCollectionResponse Create(ChatResponse chat, ICollection<ChatMessageResponse> chatMessages, long totalCount, ChatMessagesPaginationQuery pagination);
}
