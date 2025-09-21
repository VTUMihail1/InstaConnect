namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageFilterQuery(
    string ParticipantOneId,
    string ParticipantTwoId);
