using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Abstractions;

internal interface ISortOrder
{
    public SortOrder SortOrder { get; }

    public string Order { get; }
}
