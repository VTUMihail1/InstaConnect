using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includes;

public class UserChatsIncludeProperty : IUserIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public UserChatsIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.Chats;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _chatsContext.Chats,
                p => p.Id,
                l => l.Id.ParticipantOneId,
                p => p.Chats
            )
            .IncludeMany(
                _chatsContext.Chats,
                p => p.Id,
                l => l.Id.ParticipantTwoId,
                p => p.Chats
            );
    }
}
