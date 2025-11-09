using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface ISortOrderFactory
{
    ISortOrder Create(SortOrder sortOrder);
}
