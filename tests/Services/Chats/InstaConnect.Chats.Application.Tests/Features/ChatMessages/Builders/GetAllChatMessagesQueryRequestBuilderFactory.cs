namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class GetAllChatMessagesQueryRequestBuilderFactory
{
	public GetAllChatMessagesQueryRequestBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
