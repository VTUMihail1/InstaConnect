using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;
public class AscendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.ASC;

    public string Order => SortOrderUtilities.Asc;
}
