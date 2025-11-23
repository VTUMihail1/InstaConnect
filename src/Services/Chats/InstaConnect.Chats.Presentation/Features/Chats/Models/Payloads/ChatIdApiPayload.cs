namespace InstaConnect.Chats.Application.Features.Users.Models;

public record ChatIdApiPayload(UserIdApiPayload ParticipantOneId, UserIdApiPayload ParticipantTwoId);
