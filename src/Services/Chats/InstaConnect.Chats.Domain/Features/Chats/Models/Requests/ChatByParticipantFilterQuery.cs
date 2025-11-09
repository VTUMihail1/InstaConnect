namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatByParticipantFilterQuery(
    string ParticipantId,
    string ParticipantName);
