using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;
internal class SortOrderFactory : ISortOrderFactory
{
    private readonly IEnumerable<ISortOrder> _sortOrders;

    public SortOrderFactory(IEnumerable<ISortOrder> sortOrders)
    {
        _sortOrders = sortOrders;
    }

    public ISortOrder Create(SortOrder sortOrder)
    {
        var order = _sortOrders.FirstOrDefault(s => s.SortOrder == sortOrder);

        if (order == null)
        {
            throw new SortOrderNotSupportedException(sortOrder);
        }

        return order;
    }
}
