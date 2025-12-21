using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatRepository
{
    Task<ChatCollection> GetAllByParticipantAsync(
        ChatByParticipantFilterQuery filter,
        CommonSortingQuery<ChatByParticipantSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<ChatIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(
        ChatId id,
        CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(
        ChatId id,
        CommonIncludeQuery<ChatIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task AddAsync(Chat entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Chat entity, CancellationToken cancellationToken);
}
