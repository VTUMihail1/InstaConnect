using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortOrdererFactory
{
    ISortOrderer Create(CommonSortOrder sortOrder);
}
