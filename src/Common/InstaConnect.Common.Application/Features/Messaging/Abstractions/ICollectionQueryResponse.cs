namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface ICollectionQueryResponse
{
    public int Page { get; }

    public int PageSize { get; }

    public long TotalCount { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}
