using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;
public class AscendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.ASC;

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortProperty)
    {
        return Builders<TDocument>.Sort.Ascending(sortProperty);
    }
}
