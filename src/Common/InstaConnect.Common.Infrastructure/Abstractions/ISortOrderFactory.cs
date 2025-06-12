using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Abstractions;
internal interface ISortOrderFactory
{
    ISortOrder Get(SortOrder sortOrder);
}