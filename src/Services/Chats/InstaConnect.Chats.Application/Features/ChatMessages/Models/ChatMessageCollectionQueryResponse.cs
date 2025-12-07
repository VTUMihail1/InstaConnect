namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageCollectionQueryResponse(
    ICollection<ChatMessageQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
