namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Models;

public record ChatMessageApiResponse(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    ChatMessageUserApiResponse Sender);
