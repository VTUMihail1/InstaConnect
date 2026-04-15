using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Application.Abstractions;

public interface ISortableQueryRequest<out TSortTerm>
    where TSortTerm : Enum
{
    public CommonSortOrder SortOrder { get; }

    public TSortTerm SortTerm { get; }
}
