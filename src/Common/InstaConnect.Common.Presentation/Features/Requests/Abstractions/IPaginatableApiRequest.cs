namespace InstaConnect.Common.Presentation.Features.Requests.Abstractions;

public interface IPaginatableApiRequest
{
	public int Page { get; }

	public int PageSize { get; }
}
