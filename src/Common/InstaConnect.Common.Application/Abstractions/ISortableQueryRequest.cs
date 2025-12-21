using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Application.Abstractions;
public interface ISortableQueryRequest<out TSortProperty>
    where TSortProperty : Enum
{
    public CommonSortOrder SortOrder { get; }

    public TSortProperty SortProperty { get; }
}
