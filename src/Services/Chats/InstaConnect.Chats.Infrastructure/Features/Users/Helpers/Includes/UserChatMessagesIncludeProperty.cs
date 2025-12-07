using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includes;

public class UserChatMessagesIncludeProperty : IUserIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public UserChatMessagesIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.ChatMessages;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _chatsContext.ChatMessages,
                p => p.Id,
                l => l.SenderId,
                p => p.ChatMessages
            );
    }
}
