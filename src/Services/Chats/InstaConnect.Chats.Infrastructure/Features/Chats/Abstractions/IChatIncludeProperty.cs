namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncludeProperty : IIncluder<Chat>
{
    public ChatIncludeProperty IncludeProperty { get; }
}
