namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageCommandBuilderFactory
{
	public UpdateChatMessageCommandBuilder Create(ChatMessage chatMessage)
	{
		return new(chatMessage);
	}
}
