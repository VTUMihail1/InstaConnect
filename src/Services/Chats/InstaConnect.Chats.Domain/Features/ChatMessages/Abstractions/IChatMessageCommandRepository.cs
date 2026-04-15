namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageCommandRepository
{
    Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken);

    Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(ChatMessageId id, CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(ChatMessageId id, ChatMessageInclude? include, CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(ChatMessageId id, CancellationToken cancellationToken);
}
