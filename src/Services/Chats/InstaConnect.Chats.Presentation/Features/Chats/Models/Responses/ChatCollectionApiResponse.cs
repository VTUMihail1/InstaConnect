namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatCollectionApiResponse(
    ICollection<ChatApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionApiResponse;
