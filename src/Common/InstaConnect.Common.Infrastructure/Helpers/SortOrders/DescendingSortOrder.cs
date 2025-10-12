using System.Linq.Expressions;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;

public class DescendingSortOrder : ISortOrder
{
    public SortOrder SortOrder => SortOrder.DESC;

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortProperty)
    {
        return Builders<TDocument>.Sort.Descending(sortProperty);
    }
}
