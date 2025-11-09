namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includes;
internal class ChatIncludePropertyFactory : IChatIncludePropertyFactory
{
    private readonly IEnumerable<IChatIncludeProperty> _chatIncludeProperty;

    public ChatIncludePropertyFactory(IEnumerable<IChatIncludeProperty> chatIncludeProperty)
    {
        _chatIncludeProperty = chatIncludeProperty;
    }

    public IEnumerable<IChatIncludeProperty> Create(ICollection<ChatIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _chatIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ChatIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
