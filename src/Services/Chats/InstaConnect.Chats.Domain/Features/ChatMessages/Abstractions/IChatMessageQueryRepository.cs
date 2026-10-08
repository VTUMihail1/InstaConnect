namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageQueryRepository
{
	public Task<ICollection<ChatMessageResponse>> GetAllAsync(
		ChatMessagesFilterQuery filter,
		ChatMessagesSortingQuery sorting,
		ChatMessagesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		ChatMessagesFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<ChatMessageResponse?> GetByIdAsync(
		ChatMessageId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken);
}
