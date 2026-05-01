using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface ISortableQueryRequest<out TSortTerm>
	where TSortTerm : Enum
{
	public CommonSortOrder SortOrder { get; }

	public TSortTerm SortTerm { get; }
}
