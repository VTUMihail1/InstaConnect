using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includes;
public class ChatParticipantOneIncludeProperty : IChatIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public ChatParticipantOneIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public ChatIncludeProperty IncludeProperty => ChatIncludeProperty.ParticipantOne;

    public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> pipeline)
    {
        return pipeline
            .IncludeOne(
                _chatsContext.Users,
                p => p.Id.ParticipantOneId,
                u => u.Id,
                p => p.ParticipantOne!
            );
    }
}
