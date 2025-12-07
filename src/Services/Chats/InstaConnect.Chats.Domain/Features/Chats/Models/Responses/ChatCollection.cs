namespace InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
public record ChatCollection(
    ICollection<Chat> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
