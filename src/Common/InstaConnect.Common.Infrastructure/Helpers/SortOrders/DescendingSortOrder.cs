using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;

public class DescendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.DESC;

    public string Order => SortOrderUtilities.Desc;
}
