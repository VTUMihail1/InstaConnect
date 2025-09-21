namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;

public record AddChatMessageCommandResponse(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
