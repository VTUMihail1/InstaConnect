namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatCommandRepository
{
    Task AddAsync(Chat entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Chat entity, CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(ChatId id, CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(ChatId id, ChatInclude? include, CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(ChatId id, CancellationToken cancellationToken);
}
