using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includes;

public class ChatMessageIncludeProperty : IChatIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public ChatMessageIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public ChatIncludeProperty IncludeProperty => ChatIncludeProperty.Messages;

    public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> pipeline)
    {
        return pipeline
            .IncludeMany(
                _chatsContext.ChatMessages,
                p => p.Id,
                u => u.Id.Id,
                p => p.Messages
            );
    }
}
