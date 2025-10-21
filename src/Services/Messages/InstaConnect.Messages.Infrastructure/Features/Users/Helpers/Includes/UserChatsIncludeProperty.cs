using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
            .Lookup<User, Chat, User>(
                _chatsContext.Chats,
                p => p.Id,
                l => l.ParticipantOne,
                p => p.Chats
            )
            .Lookup<User, Chat, User>(
                _chatsContext.Chats,
                p => p.Id,
                l => l.ParticipantTwo,
                p => p.Chats
            );
    }
}
