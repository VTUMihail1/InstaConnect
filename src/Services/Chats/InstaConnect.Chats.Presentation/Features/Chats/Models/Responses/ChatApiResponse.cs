namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatApiResponse(
	string ParticipantOneId,
	string ParticipantTwoId,
	UserApiResponse? ParticipantOne,
	UserApiResponse? ParticipantTwo,
	DateTimeOffset CreatedAtUtc);
