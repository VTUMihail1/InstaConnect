namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageApiRequestBuilderFactory
{
	public DeleteChatMessageApiRequestBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
