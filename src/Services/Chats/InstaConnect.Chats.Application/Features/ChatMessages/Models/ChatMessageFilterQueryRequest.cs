namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageFilterQueryRequest(ChatIdPayload Id, UserIdPayload SenderId);
