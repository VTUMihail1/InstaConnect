namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetAllChatMessagesTotalCountQueryParameters(
    string ParticipantOneId,
    string ParticipantTwoId);
