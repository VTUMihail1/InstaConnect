using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatParticipantOneIncluder : IChatMessageIncluder
{
	private readonly IChatsContext _context;

	public ChatParticipantOneIncluder(IChatsContext context)
	{
		_context = context;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.Chat;

	public ChatsIncludeType IncludeType => ChatsIncludeType.ParticipantOne;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Users,
				p => p.Id.Id.ParticipantOneId,
				u => u.Id,
				p => p.Chat!.ParticipantOne!
			);
	}
}
