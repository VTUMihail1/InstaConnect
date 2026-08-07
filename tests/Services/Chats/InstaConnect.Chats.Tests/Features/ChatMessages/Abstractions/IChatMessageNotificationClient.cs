
namespace InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;

public interface IChatMessageNotificationClient
{
	public Task StartAsync(CancellationToken cancellationToken);

	public Task StopAsync(CancellationToken cancellationToken);

	public Task<ChatMessageAddedNotificationRequest> PublishedAddedAsync(CancellationToken cancellationToken);

	public Task<ChatMessageUpdatedNotificationRequest> PublishedUpdatedAsync(CancellationToken cancellationToken);

	public Task<ChatMessageDeletedNotificationRequest> PublishedDeletedAsync(CancellationToken cancellationToken);
}
