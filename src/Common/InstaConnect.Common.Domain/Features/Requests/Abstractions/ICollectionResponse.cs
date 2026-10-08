namespace InstaConnect.Common.Domain.Features.Requests.Abstractions;

public interface ICollectionResponse
{
	public int Page { get; }

	public int PageSize { get; }

	public long TotalCount { get; }

	public bool HasNextPage { get; }

	public bool HasPreviousPage { get; }
}
