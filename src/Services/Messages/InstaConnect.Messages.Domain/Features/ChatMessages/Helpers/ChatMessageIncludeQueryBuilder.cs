using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Helpers;

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
