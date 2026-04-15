namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageFactory
{
    public ChatMessage Create(ChatId id, UserId senderId, string content);
}
