namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record UpdateChatMessageApiResponse(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string Content,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
