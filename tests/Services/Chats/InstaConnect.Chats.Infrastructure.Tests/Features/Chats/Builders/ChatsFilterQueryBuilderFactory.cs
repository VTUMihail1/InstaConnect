using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

public class ChatsFilterQueryBuilderFactory
{
	public ChatsFilterQueryBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
