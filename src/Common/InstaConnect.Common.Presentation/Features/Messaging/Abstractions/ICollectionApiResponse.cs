namespace InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

public interface ICollectionApiResponse
{
    public int Page { get; }

    public int PageSize { get; }

    public long TotalCount { get; }

    public bool HasNextPage { get; }

    public bool HasPreviousPage { get; }
}
