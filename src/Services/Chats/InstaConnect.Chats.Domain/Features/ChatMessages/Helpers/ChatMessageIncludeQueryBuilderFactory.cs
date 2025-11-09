namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeQueryBuilderFactory : IChatMessageIncludeQueryBuilderFactory
{
    public ChatMessageIncludeQueryBuilder Create()
    {
        return new ChatMessageIncludeQueryBuilder([]);
    }
}
