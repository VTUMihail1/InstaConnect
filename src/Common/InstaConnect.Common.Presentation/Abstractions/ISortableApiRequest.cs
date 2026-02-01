using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Presentation.Abstractions;
public interface ISortableApiRequest<out TSortTerm>
    where TSortTerm : Enum
{
    public CommonSortOrder SortOrder { get; }

    public TSortTerm SortTerm { get; }
}
