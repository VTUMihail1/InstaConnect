namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatRepository
{
    Task<ChatCollection> GetAllByParticipantAsync(
        ChatByParticipantFilterQuery filter,
        ChatByParticipantSortingQuery sorting,
        ChatPaginationQuery pagination,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(
        ChatId id,
        CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(
        ChatId id,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken);

    Task AddAsync(Chat entity, CancellationToken cancellationToken);

    Task DeleteAsync(Chat entity, CancellationToken cancellationToken);
}
