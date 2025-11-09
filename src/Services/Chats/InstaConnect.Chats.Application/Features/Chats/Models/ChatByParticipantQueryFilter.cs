namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatByParticipantQueryFilter(
    string ParticipantId,
    string ParticipantName);
