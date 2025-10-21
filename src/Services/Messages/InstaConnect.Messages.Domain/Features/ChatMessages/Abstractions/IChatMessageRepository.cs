using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageRepository
{
    Task<ChatMessageCollection> GetAllAsync(
        ChatMessageFilterQuery filter,
        ChatMessageSortingQuery sorting,
        ChatMessagePaginationQuery pagination,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        string messageId,
        ChatMessageIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(
        string participantOneId,
        string participantTwoId,
        string messageId,
        CancellationToken cancellationToken);

    Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken);

    Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken);
}
