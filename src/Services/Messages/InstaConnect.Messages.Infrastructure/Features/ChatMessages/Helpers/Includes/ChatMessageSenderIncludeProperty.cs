using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Messages.Infrastructure.Features.ChatMessages.Helpers.Includes;

public class ChatMessageSenderIncludeProperty : IChatMessageIncludeProperty
{
    private readonly IChatsContext _chatsContext;

    public ChatMessageSenderIncludeProperty(IChatsContext chatsContext)
    {
        _chatsContext = chatsContext;
    }

    public ChatMessageIncludeProperty IncludeProperty => ChatMessageIncludeProperty.Sender;

    public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> pipeline)
    {
        return pipeline
            .Lookup<ChatMessage, User, ChatMessage>(
                _chatsContext.Users,
                p => p.SenderId,
                u => u.Id,
                p => p.Sender
            );
    }
}
