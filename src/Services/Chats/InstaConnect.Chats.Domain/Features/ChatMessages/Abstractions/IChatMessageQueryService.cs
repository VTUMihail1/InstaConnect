namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageQueryService
{
    public Task<ChatMessageCollectionResponse> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken);

    public Task<ChatMessageResponse> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken);
}
