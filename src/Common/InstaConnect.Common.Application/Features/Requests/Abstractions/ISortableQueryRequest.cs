using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Application.Features.Requests.Abstractions;

public interface ISortableQueryRequest<out TSortTerm>
	where TSortTerm : Enum
{
	public CommonSortOrder SortOrder { get; }

	public TSortTerm SortTerm { get; }
}
