
namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

public record ChatMessageNotificationRequest(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	UserNotificationRequest Sender,
	string Content,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
