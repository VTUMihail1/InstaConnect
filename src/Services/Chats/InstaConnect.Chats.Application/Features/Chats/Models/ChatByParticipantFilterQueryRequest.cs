namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatByParticipantFilterQueryRequest(
    UserIdPayload ParticipantId,
    NamePayload ParticipantName);
