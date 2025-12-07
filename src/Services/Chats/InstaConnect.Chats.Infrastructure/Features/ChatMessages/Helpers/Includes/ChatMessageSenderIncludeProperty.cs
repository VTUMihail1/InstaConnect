using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includes;

public class ChatMessageSenderIncludeProperty : IChatMessageIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public ChatMessageSenderIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public ChatMessageIncludeProperty IncludeProperty => ChatMessageIncludeProperty.Sender;

    public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> pipeline)
    {
        return pipeline
            .IncludeOne(
                _chatsContext.Users,
                p => p.SenderId,
                u => u.Id,
                p => p.Sender!
            );
    }
}
