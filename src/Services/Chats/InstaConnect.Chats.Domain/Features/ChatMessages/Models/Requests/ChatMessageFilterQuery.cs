namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageFilterQuery(
    string ParticipantOneId,
    string ParticipantTwoId);
