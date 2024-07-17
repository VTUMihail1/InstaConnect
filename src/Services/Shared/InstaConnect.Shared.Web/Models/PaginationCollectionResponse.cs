namespace InstaConnect.Shared.Web.Models;

public class PaginationCollectionResponse<T>
{
    public ICollection<T> Items { get; set; } = new List<T>();

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public bool HasNextPage { get; set; }

    public bool HasPreviousPage { get; set; }
}
