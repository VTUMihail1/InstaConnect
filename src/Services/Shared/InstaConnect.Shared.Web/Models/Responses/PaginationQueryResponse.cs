namespace InstaConnect.Shared.Web.Models.Responses;

public record PaginationQueryResponse<T>(
    ICollection<T> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
