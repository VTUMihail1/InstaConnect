namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQueryResponse(
    ChatMessageIdPayload Id,
    string Content,
    UserQueryResponse Sender,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
