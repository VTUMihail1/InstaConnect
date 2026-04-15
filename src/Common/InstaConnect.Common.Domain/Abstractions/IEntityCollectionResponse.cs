namespace InstaConnect.Common.Domain.Abstractions;

public interface IEntityCollectionResponse
{
    public int Page { get; }

    public int PageSize { get; }

    public long TotalCount { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}
