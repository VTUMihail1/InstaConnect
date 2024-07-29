using InstaConnect.Shared.Web.Models.Responses;

namespace InstaConnect.Messages.Web.Features.Messages.Models.Responses;

public record MessagePaginationCollectionQueryResponse(
    ICollection<MessageQueryViewResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryResponse<MessageQueryViewResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
