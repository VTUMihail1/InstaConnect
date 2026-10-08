using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Presentation.Features.Requests.Abstractions;

public interface ISortableApiRequest<out TSortTerm>
	where TSortTerm : Enum
{
	public CommonSortOrder SortOrder { get; }

	public TSortTerm SortTerm { get; }
}
