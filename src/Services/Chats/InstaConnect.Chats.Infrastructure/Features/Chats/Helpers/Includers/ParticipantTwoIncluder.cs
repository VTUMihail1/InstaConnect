using InstaConnect.Chats.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ParticipantTwoIncluder : IChatIncluder
{
    private readonly IChatsContext _context;

    public ParticipantTwoIncluder(IChatsContext context)
    {
        _context = context;
    }

    public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

    public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantTwo;

    public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.ParticipantTwoId,
                u => u.Id,
                p => p.ParticipantTwo!
            );
    }
}
