namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record ChatMessageCollectionApiResponse(
    ICollection<ChatMessageApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionApiResponse;
