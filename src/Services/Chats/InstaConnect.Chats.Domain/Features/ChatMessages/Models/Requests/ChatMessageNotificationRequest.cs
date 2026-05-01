namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageNotificationRequest(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	UserNotificationRequest Sender,
	ChatNotificationRequest Chat,
	string Content,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
