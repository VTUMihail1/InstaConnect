namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class AddChatApiRequestBuilderFactory
{
    public AddChatApiRequestBuilder Create(User participantOne, User participantTwo)
    {
        return new(participantOne, participantTwo);
    }
}
