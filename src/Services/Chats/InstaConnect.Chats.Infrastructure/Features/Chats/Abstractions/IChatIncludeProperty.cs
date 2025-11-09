namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncludeProperty : IIncludeProperty<Chat>
{
    public ChatIncludeProperty IncludeProperty { get; }
}
