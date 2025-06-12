using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class DescendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.DESC;

    public string Order => SortOrderUtilities.Desc;
}
