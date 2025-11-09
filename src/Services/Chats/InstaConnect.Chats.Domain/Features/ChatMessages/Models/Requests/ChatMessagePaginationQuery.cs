namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessagePaginationQuery(
    int Page,
    int PageSize);
