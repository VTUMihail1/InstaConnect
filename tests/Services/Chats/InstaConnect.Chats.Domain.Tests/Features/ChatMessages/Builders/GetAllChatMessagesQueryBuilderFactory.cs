namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesQueryBuilderFactory
{
	public GetAllChatMessagesQueryBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
