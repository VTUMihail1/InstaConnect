using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatParticipantTwoIncluder : IChatMessageIncluder
{
    private readonly IChatsContext _context;

    public ChatParticipantTwoIncluder(IChatsContext context)
    {
        _context = context;
    }

    public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

    public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantTwo;

    public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.Id.ParticipantTwoId,
                u => u.Id,
                p => p.Chat!.ParticipantTwo!
            );
    }
}
