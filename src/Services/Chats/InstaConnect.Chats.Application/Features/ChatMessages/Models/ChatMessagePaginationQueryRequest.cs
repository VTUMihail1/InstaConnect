namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessagePaginationQueryRequest(
    int Page,
    int PageSize);
