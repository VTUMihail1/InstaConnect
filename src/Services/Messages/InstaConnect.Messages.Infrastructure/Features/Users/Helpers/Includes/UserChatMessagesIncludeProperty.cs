using InstaConnect.ChatLikes.Domain.Features.ChatLikes.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class UserChatMessagesIncludeProperty : IUserIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public UserChatLikesIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.ChatMessages;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, ChatMessage, User>(
                _chatsContext.ChatMessages,
                p => p.Id,
                l => l.SenderId,
                p => p.ChatMessages
            );
    }
}
