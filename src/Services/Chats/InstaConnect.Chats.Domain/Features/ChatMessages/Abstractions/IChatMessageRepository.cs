namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageRepository
{
    Task<ChatMessageCollection> GetAllAsync(
        ChatMessageFilterQuery filter,
        ChatMessageSortingQuery sorting,
        ChatPaginationQuery pagination,
        ChatMessageInclude include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        ChatMessageInclude include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken);

    Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken);

    Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken);
}
