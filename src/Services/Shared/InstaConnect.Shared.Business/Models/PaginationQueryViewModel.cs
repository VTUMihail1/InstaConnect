namespace InstaConnect.Shared.Business.Models;
public abstract record PaginationQueryViewModel<T>(
    ICollection<T> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
