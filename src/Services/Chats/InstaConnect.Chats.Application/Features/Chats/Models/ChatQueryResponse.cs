namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatQueryResponse(
    UserQueryResponse ParticipantOne,
    UserQueryResponse ParticipantTwo,
    DateTimeOffset CreatedAtUtc);
