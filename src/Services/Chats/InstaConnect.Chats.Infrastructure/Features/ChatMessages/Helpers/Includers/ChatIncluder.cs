using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Includers;

internal class ChatIncluder : IChatMessageIncluder
{
	private readonly IChatsContext _context;

	public ChatIncluder(IChatsContext context)
	{
		_context = context;
	}

	public ChatsDestinationType DestinationType => ChatsDestinationType.ChatMessage;

	public ChatsIncludeType IncludeType => ChatsIncludeType.Chat;

	public IAggregateFluent<ChatMessage> Include(IAggregateFluent<ChatMessage> aggregate)
	{
		return aggregate
			.IncludeOne(
				_context.Chats,
				p => p.Id.Id,
				u => u.Id,
				p => p.Chat!
			);
	}
}
