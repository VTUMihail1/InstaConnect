namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Builders;

public class GetAllChatsApiRequestBuilderFactory
{
    public GetAllChatsApiRequestBuilder Create(Chat chat)
    {
        return new(chat);
    }
}
