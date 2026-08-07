namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageCommandBuilderFactory
{
	public DeleteChatMessageCommandBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
