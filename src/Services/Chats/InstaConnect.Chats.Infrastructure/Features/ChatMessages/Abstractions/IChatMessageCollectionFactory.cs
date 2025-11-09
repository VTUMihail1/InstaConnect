namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
internal interface IChatMessageCollectionFactory
{
    ChatMessageCollection Create(ICollection<ChatMessage> chatMessages, int totalCount, ChatMessagePaginationQuery pagination);
}
