using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;

public interface IChatMessageHubClient
{
	public Task Added(ChatMessageAddedNotificationRequest request);

	public Task Updated(ChatMessageUpdatedNotificationRequest request);

	public Task Deleted(ChatMessageDeletedNotificationRequest request);
}
