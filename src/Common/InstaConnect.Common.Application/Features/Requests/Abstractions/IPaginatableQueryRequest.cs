namespace InstaConnect.Common.Application.Features.Requests.Abstractions;

public interface IPaginatableQueryRequest
{
	public int Page { get; }

	public int PageSize { get; }
}
