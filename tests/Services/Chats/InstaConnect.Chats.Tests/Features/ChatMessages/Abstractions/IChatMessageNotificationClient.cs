
namespace InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;

public interface IChatMessageNotificationClient
{
	public Task ConnectAsync(CancellationToken cancellationToken);

	public Task<ChatMessageAddedNotificationRequest> AddedAsync(CancellationToken cancellationToken);

	public Task<ChatMessageUpdatedNotificationRequest> UpdatedAsync(CancellationToken cancellationToken);

	public Task<ChatMessageDeletedNotificationRequest> DeletedAsync(CancellationToken cancellationToken);
}
