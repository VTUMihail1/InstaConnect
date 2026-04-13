namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageApiRequestBuilderFactory
{
    public UpdateChatMessageApiRequestBuilder Create(ChatMessage chatMessage)
    {
        return new(chatMessage);
    }
}
