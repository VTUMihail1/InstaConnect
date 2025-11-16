using System.Linq.Expressions;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;
public class AscendingSortOrder : ISortOrder
{
    public CommonSortOrder SortOrder => CommonSortOrder.ASC;

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortProperty)
    {
        return Builders<TDocument>.Sort.Ascending(sortProperty);
    }
}
