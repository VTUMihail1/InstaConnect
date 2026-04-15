using System.Linq.Expressions;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Helpers.SortOrders;

public class AscendingSortOrderer : ISortOrderer
{
    public CommonSortOrder SortOrder => CommonSortOrder.Ascending;

    public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm)
    {
        return Builders<TDocument>.Sort.Ascending(sortTerm);
    }
}
