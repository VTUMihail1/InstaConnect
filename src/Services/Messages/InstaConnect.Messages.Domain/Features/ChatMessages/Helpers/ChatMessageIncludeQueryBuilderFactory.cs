using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeQueryBuilderFactory : IChatMessageIncludeQueryBuilderFactory
{
    public ChatMessageIncludeQueryBuilder Create()
    {
        return new ChatMessageIncludeQueryBuilder([]);
    }
}
