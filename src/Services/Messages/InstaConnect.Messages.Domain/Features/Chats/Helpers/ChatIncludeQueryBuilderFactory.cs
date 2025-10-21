using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

public class ChatIncludeQueryBuilderFactory : IChatIncludeQueryBuilderFactory
{
    public ChatIncludeQueryBuilder Create()
    {
        return new ChatIncludeQueryBuilder([]);
    }
}
