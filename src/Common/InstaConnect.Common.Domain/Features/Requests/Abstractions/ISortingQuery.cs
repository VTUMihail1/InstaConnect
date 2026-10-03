using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Domain.Features.Requests.Abstractions;

public interface ISortingQuery<out TSortTerm>
	where TSortTerm : Enum
{
	public CommonSortOrder Order { get; }

	public TSortTerm Term { get; }
}
