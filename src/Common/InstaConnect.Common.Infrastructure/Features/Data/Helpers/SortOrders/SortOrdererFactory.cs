using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Helpers.SortOrders;

internal class SortOrdererFactory : ISortOrdererFactory
{
	private readonly IEnumerable<ISortOrderer> _sortOrderers;

	public SortOrdererFactory(IEnumerable<ISortOrderer> sortOrders)
	{
		_sortOrderers = sortOrders;
	}

	public ISortOrderer Create(CommonSortOrder sortOrder)
	{
		var sortOrderers = _sortOrderers.FirstOrDefault(s => s.SortOrder == sortOrder);

		if (sortOrderers == null)
		{
			throw new SortOrderNotSupportedException(sortOrder);
		}

		return sortOrderers;
	}
}
