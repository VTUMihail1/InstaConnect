using InstaConnect.Chats.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includers;

internal class ChatsIncluder : IUserIncluder
{
    private readonly IChatsContext _context;

    public ChatsIncluder(IChatsContext context)
    {
        _context = context;
    }

    public ChatsDestinationType DestinationType => ChatsDestinationType.User;

    public ChatsIncludeType IncludeType => ChatsIncludeType.Chat;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.Chats,
                p => p.Id,
                l => l.Id.ParticipantOneId,
                p => p.Chats
            )
            .IncludeMany(
                _context.Chats,
                p => p.Id,
                l => l.Id.ParticipantTwoId,
                p => p.Chats
            );
    }
}
