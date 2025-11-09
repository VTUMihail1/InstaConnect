namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeProperty : IIncludeProperty<ChatMessage>
{
    public ChatMessageIncludeProperty IncludeProperty { get; }
}
