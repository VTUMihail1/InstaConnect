using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

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
        string participantOneId,
        string participantTwoId,
        CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        ChatIncludeQuery? include,
        CancellationToken cancellationToken);

    Task AddAsync(Chat entity, CancellationToken cancellationToken);

    Task DeleteAsync(Chat entity, CancellationToken cancellationToken);

    Task UpdateAsync(Chat entity, CancellationToken cancellationToken);
}
