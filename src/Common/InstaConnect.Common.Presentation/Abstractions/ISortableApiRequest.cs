using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Presentation.Abstractions;
public interface ISortableApiRequest<out TSortProperty>
    where TSortProperty : Enum
{
    public CommonSortOrder SortOrder { get; }

    public TSortProperty SortProperty { get; }
}
