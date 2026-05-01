namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class AddChatCommandRequestBuilderFactory
{
	public AddChatCommandRequestBuilder Create(User participantOne, User participantTwo)
	{
		return new(participantOne, participantTwo);
	}
}
