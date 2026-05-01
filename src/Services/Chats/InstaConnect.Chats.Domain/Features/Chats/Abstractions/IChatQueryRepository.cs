namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatQueryRepository
{
	public Task<ICollection<ChatResponse>> GetAllAsync(
		ChatsFilterQuery filter,
		CurrentUserQuery currentUser,
		ChatsSortingQuery sorting,
		ChatsPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		ChatsFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<ChatResponse?> GetByIdAsync(
		ChatId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		ChatId id,
		CancellationToken cancellationToken);
}
