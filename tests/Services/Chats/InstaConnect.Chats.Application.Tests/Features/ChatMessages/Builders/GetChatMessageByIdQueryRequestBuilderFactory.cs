namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdQueryRequestBuilderFactory
{
    public GetChatMessageByIdQueryRequestBuilder Create(ChatMessage chatMessage)
    {
        return new(chatMessage);
    }
}
