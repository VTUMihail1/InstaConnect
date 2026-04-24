using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface ISortOrdererFactory
{
    ISortOrderer Create(CommonSortOrder sortOrder);
}
