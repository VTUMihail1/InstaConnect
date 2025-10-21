using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

using MongoDB.Driver;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
