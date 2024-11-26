namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;

public record MessagePaginationCollectionQueryResponse(
    ICollection<MessageQueryViewResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
