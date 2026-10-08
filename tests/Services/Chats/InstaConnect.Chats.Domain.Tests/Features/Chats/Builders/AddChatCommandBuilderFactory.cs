namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;

public class AddChatCommandBuilderFactory
{
	public AddChatCommandBuilder Create(User participantOne, User participantTwo)
	{
		return new(participantOne, participantTwo);
	}
}
