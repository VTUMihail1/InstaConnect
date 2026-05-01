namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageCommandRequestBuilderFactory
{
	public DeleteChatMessageCommandRequestBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
