namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageQueryRepository
{
    Task<ICollection<ChatMessageResponse>> GetAllAsync(
        ChatMessagesFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatMessagesSortingQuery sorting,
        ChatMessagesPaginationQuery pagination,
        ChatMessageInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<ChatMessageResponse>> GetAllAsync(
        ChatMessagesFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatMessagesSortingQuery sorting,
        ChatMessagesPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        ChatMessagesFilterQuery filter,
        ChatMessageInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        ChatMessagesFilterQuery filter,
        CancellationToken cancellationToken);

    Task<ChatMessageResponse?> GetByIdAsync(
        ChatMessageId id,
        CurrentUserQuery currentUser,
        ChatMessageInclude? include,
        CancellationToken cancellationToken);

    Task<ChatMessageResponse?> GetByIdAsync(
        ChatMessageId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken);
}
