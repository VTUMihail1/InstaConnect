using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

public interface ISortOrdererFactory
{
	public ISortOrderer Create(CommonSortOrder sortOrder);
}
