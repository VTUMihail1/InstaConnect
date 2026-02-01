namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeProperty : IIncluder<ChatMessage>
{
    public ChatMessageIncludeProperty IncludeProperty { get; }
}
