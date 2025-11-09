namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

public record UpdateChatMessageCommandResponse(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
