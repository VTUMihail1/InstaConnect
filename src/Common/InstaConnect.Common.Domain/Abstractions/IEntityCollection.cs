namespace InstaConnect.Common.Domain.Abstractions;

public interface IEntityCollection
{
    public int Page { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}
