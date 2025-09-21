namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record GetChatMessageByIdQueryParameters(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId);
