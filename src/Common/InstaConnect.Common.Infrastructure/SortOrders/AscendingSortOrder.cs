using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.SortOrders;
public class AscendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.ASC;

    public string Order => SortOrderUtilities.Asc;
}
