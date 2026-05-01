namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdApiRequestBuilderFactory
{
	public GetChatMessageByIdApiRequestBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
