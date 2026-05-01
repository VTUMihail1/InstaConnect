namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatBuilderFactory
{
	public ChatBuilder Create(User participantOne, User participantTwo)
	{
		return new(participantOne, participantTwo);
	}
}
