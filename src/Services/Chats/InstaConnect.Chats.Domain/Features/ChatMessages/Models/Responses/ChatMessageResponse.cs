using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

public record ChatMessageResponse(
    ChatMessageId Id,
    string Content,
    UserId SenderId,
    ChatResponse? Chat,
    UserResponse? Sender,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc) : IEntityResponse;
