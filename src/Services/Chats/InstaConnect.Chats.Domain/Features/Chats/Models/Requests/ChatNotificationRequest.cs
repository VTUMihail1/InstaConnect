namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatNotificationRequest(
		string ParticipantOneId,
		string ParticipantTwoId,
		UserNotificationRequest ParticipantOne,
		UserNotificationRequest ParticipantTwo,
		DateTimeOffset CreatedAtUtc);
