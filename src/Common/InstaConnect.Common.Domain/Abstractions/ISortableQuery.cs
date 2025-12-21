using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Abstractions;

public interface ISortableQuery<TSortProperty>
    where TSortProperty : Enum
{
    public CommonSortingQuery<TSortProperty> Sorting { get; }
}
