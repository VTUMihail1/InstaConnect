using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers.SortOrders;

public class DescendingSortOrderer : ISortOrderer
{
	public CommonSortOrder SortOrder => CommonSortOrder.Descending;

	public SortDefinition<TDocument> Sort<TDocument>(Expression<Func<TDocument, object>> sortTerm)
	{
		return Builders<TDocument>.Sort.Descending(sortTerm);
	}
}
