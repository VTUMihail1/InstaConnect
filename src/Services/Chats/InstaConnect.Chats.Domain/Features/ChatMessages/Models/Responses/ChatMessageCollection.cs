namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
public record ChatMessageCollection(
    ICollection<ChatMessage> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
