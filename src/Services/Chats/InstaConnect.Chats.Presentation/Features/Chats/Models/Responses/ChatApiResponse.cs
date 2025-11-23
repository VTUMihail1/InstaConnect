namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatApiResponse(
    ChatIdApiPayload Id,
    UserApiResponse ParticipantOne,
    UserApiResponse ParticipantTwo,
    DateTimeOffset CreatedAtUtc);
