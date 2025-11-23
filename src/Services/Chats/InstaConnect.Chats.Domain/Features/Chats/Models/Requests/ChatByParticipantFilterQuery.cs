namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatByParticipantFilterQuery(
    UserId ParticipantId,
    Name ParticipantName);
