using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Includers;

internal class ParticipantOneIncluder : IChatIncluder
{
	private readonly IChatsContext _context;

	public ParticipantOneIncluder(IChatsContext context)
	{
		_context = context;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantOne;

	public IAggregateFluent<Chat> Include(IAggregateFluent<Chat> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Users,
				p => p.Id.ParticipantOneId,
				u => u.Id,
				p => p.ParticipantOne!
			);
	}
}
