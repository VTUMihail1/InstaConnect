namespace InstaConnect.Common.Domain.Features.Data.Abstractions;

public interface IPaginator
{
	public int GetOffset(int page, int pageSize);

	public bool HasNextPage(int page, int pageSize, long totalCount);

	public bool HasPreviousPage(int page);
}
