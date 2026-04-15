namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetChatByIdApiRequestBuilderFactory
{
    public GetChatByIdApiRequestBuilder Create(Chat chat)
    {
        return new(chat);
    }
}
