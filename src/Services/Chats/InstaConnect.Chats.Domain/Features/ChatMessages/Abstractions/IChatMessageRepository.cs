namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageRepository
{
    Task<ChatMessageCollection> GetAllAsync(
        ChatMessageFilterQuery filter,
        ChatMessageSortingQuery sorting,
        ChatMessagePaginationQuery pagination,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken);

    Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken);
}
