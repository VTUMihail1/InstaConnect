namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;

public record MessagePaginationQueryResponse(
    ICollection<MessageQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
