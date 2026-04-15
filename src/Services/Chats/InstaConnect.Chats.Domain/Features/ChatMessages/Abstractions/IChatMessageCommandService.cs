namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageCommandService
{
    public Task<ChatMessageId> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken);

    public Task<ChatMessageId> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken);
}
