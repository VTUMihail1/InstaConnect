namespace InstaConnect.Common.Presentation.Abstractions;

public interface ICollectionApiResponse
{
    public int Page { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}
