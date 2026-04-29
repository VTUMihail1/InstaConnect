namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record ChatMessageApiResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	string MessageId,
	string SenderId,
	string Content,
	ChatApiResponse? Chat,
	UserApiResponse? Sender,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
