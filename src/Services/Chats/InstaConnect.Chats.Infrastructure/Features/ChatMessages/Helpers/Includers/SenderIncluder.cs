using InstaConnect.Chats.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class SenderIncluder : IChatMessageIncluder
{
    private readonly IChatsContext _context;

    public SenderIncluder(IChatsContext context)
    {
        _context = context;
    }

    public ChatsDestinationType DestinationType => ChatsDestinationType.ChatMessage;

    public ChatsIncludeType IncludeType => ChatsIncludeType.Sender;

    public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.SenderId,
                u => u.Id,
                p => p.Sender!
            );
    }
}
