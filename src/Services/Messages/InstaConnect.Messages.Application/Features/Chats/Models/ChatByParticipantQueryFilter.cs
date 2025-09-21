namespace InstaConnect.Chats.Domain.Features.Chats.Models;

public record ChatByParticipantQueryFilter(
    string ParticipantId,
    string ParticipantName);
