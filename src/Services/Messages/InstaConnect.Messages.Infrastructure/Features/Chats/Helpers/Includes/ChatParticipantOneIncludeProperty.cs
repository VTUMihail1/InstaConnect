using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

using MongoDB.Driver;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Common.Infrastructure.SortOrders;
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
            .Lookup<Chat, User, Chat>(
                _chatsContext.Users,
                p => p.ParticipantOneId,
                u => u.Id,
                p => p.ParticipantOne 
            );
    }
}
