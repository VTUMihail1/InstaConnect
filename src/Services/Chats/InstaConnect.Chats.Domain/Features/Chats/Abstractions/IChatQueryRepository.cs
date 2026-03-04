namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatQueryRepository
{
    Task<ICollection<ChatResponse>> GetAllAsync(
        ChatsFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatsSortingQuery sorting,
        ChatsPaginationQuery pagination,
        ChatInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<ChatResponse>> GetAllAsync(
        ChatsFilterQuery filter,
        CurrentUserQuery currentUser,
        ChatsSortingQuery sorting,
        ChatsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        ChatsFilterQuery filter,
        ChatInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        ChatsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<ChatResponse?> GetByIdAsync(
        ChatId id,
        CurrentUserQuery currentUser,
        ChatInclude? include,
        CancellationToken cancellationToken);

    Task<ChatResponse?> GetByIdAsync(
        ChatId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        ChatId id,
        CancellationToken cancellationToken);
}
