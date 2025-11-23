namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatQueryResponse(
    ChatIdPayload Id,
    UserQueryResponse ParticipantOne,
    UserQueryResponse ParticipantTwo,
    DateTimeOffset CreatedAtUtc);
