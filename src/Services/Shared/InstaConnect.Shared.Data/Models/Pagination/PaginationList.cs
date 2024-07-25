namespace InstaConnect.Shared.Data.Models.Pagination;

public record PaginationList<T>(ICollection<T> Items, int Page, int PageSize, int TotalCount)
{
    public bool HasNextPage => Page * PageSize < TotalCount;

    public bool HasPreviousPage => Page > 1;
}
