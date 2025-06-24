using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.SortOrders;
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
            throw new SortOrderNotSupportedException();
        }

        return order;
    }
}
