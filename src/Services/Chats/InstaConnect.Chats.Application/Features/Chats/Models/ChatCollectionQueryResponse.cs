namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatCollectionQueryResponse(
    ICollection<ChatQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
