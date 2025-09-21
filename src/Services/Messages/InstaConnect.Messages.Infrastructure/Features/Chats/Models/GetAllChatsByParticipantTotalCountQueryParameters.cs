namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetAllChatsByParticipantTotalCountQueryParameters(
    string ParticipantId,
    string ParticipantName);
