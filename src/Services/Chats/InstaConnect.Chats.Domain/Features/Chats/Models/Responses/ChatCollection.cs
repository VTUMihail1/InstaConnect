namespace InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
public record ChatCollection(
    ICollection<Chat> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
