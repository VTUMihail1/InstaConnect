namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQueryResponse(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    UserQueryResponse Sender,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
