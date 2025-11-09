namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includes;
internal class ChatMessageIncludePropertyFactory : IChatMessageIncludePropertyFactory
{
    private readonly IEnumerable<IChatMessageIncludeProperty> _chatMessageIncludeProperty;

    public ChatMessageIncludePropertyFactory(IEnumerable<IChatMessageIncludeProperty> chatMessageIncludeProperty)
    {
        _chatMessageIncludeProperty = chatMessageIncludeProperty;
    }

    public IEnumerable<IChatMessageIncludeProperty> Create(ICollection<ChatMessageIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _chatMessageIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ChatMessageIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
