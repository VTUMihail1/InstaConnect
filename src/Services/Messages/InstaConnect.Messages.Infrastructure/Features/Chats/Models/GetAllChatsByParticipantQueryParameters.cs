namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record GetAllChatsByParticipantQueryParameters(
    string ParticipantId,
    string ParticipantName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
