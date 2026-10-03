namespace InstaConnect.Common.Domain.Features.Requests.Abstractions;

public interface IPaginationQuery
{
	public int Page { get; }

	public int PageSize { get; }
}
