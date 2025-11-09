namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeQueryBuilder
{
    private readonly ICollection<ChatMessageIncludeProperty> _includeProperties;

    internal ChatMessageIncludeQueryBuilder(ICollection<ChatMessageIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public ChatMessageIncludeQueryBuilder WithSender()
    {
        _includeProperties.Add(ChatMessageIncludeProperty.Sender);

        return this;
    }

    public ChatMessageIncludeQuery Build()
    {
        return new ChatMessageIncludeQuery(_includeProperties);
    }
}
