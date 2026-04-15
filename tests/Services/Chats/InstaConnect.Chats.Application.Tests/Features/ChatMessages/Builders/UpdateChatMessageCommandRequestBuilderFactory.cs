namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageCommandRequestBuilderFactory
{
    public UpdateChatMessageCommandRequestBuilder Create(ChatMessage chatMessage)
    {
        return new(chatMessage);
    }
}
