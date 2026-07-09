namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class GetAllChatsQueryBuilderFactory
{
	public GetAllChatsQueryBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
