using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includes;

public class ChatParticipantTwoIncludeProperty : IChatIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public ChatParticipantTwoIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public ChatIncludeProperty IncludeProperty => ChatIncludeProperty.ParticipantTwo;

    public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> pipeline)
    {
        return pipeline
            .Lookup<Chat, User, Chat>(
                _chatsContext.Users,
                p => p.ParticipantTwoId,
                u => u.Id,
                p => p.ParticipantTwo
            );
    }
}
