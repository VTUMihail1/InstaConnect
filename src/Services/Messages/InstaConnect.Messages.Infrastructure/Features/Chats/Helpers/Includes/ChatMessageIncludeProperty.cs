using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

using MongoDB.Driver;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
            .Lookup<Chat, ChatMessage, Chat>(
                _chatsContext.ChatMessages,
                p => new { p.ParticipantOneId, p.ParticipantTwoId },
                u => new { u.ParticipantOneId, u.ParticipantTwoId },
                p => p.Messages
            );
    }
}
