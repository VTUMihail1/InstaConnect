using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

public interface ISortableApiRequest<out TSortTerm>
	where TSortTerm : Enum
{
	public CommonSortOrder SortOrder { get; }

	public TSortTerm SortTerm { get; }
}
