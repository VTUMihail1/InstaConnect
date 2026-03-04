namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatCommandService
{
    public Task<ChatId> AddAsync(AddChatCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteChatCommand command, CancellationToken cancellationToken);
}
