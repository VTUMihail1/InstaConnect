namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.SortProperties;
internal class ChatMessageSortPropertyFactory : IChatMessageSortPropertyFactory
{
    private readonly IEnumerable<IChatMessageSortProperty> _chatMessageSortProperties;

    public ChatMessageSortPropertyFactory(IEnumerable<IChatMessageSortProperty> chatMessageSortProperties)
    {
        _chatMessageSortProperties = chatMessageSortProperties;
    }

    public IChatMessageSortProperty Create(ChatMessageSortProperty sortProperty)
    {
        var property = _chatMessageSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new ChatMessageSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
