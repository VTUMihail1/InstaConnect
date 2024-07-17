namespace InstaConnect.Shared.Business.Models;
public class PaginationCollectionModel<T>
{
    public ICollection<T> Items { get; set; } = new List<T>();

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public bool HasNextPage { get; set; }

    public bool HasPreviousPage { get; set; }
}
