namespace InstaConnect.Chats.Application.Tests.Features.Chats.Builders;

public class GetChatByIdQueryRequestBuilderFactory
{
    public GetChatByIdQueryRequestBuilder Create(Chat chat)
    {
        return new(chat);
    }
}
