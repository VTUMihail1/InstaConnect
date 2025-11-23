namespace InstaConnect.Chats.Application.Features.Users.Models;

public record ChatIdPayload(UserIdPayload ParticipantOneId, UserIdPayload ParticipantTwoId);
