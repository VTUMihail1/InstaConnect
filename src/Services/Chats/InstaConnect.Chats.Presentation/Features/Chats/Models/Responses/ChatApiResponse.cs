namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatApiResponse(
    UserApiResponse ParticipantOne,
    UserApiResponse ParticipantTwo,
    DateTimeOffset CreatedAtUtc);
