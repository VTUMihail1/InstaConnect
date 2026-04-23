using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includers;

internal class ChatMessagesIncluder : IUserIncluder
{
    private readonly IChatsContext _context;

    public ChatMessagesIncluder(IChatsContext context)
    {
        _context = context;
    }

    public ChatsDestinationType DestinationType => ChatsDestinationType.User;

    public ChatsIncludeType IncludeType => ChatsIncludeType.ChatMessage;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.ChatMessages,
                p => p.Id,
                l => l.SenderId,
                p => p.ChatMessages
            );
    }
}
