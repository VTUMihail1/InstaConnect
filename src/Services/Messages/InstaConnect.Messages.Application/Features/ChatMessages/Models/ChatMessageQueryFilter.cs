namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models;

public record ChatMessageQueryFilter(
    string ParticipantOneId,
    string ParticipantTwoId);
