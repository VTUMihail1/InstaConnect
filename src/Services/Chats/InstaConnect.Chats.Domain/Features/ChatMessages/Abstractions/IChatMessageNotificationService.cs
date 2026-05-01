namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageNotificationService
{
	public Task AddedAsync(ChatMessageAddedNotificationRequest request, CancellationToken cancellationToken);

	public Task UpdatedAsync(ChatMessageUpdatedNotificationRequest request, CancellationToken cancellationToken);

	public Task DeletedAsync(ChatMessageDeletedNotificationRequest request, CancellationToken cancellationToken);
}
