namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record ChatMessageApiResponse(
    ChatMessageIdApiPayload Id,
    string Content,
    UserApiResponse Sender,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
