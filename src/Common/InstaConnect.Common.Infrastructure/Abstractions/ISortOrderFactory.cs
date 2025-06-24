using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface ISortOrderFactory
{
    ISortOrder Create(SortOrder sortOrder);
}
