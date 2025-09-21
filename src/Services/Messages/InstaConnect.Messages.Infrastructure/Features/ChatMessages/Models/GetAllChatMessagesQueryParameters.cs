namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetAllChatMessagesQueryParameters(
    string ParticipantOneId,
    string ParticipantTwoId,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
