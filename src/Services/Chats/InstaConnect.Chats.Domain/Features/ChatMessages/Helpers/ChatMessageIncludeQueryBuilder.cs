using InstaConnect.Common.Domain.Models;

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

    public CommonIncludeQuery<ChatMessageIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
