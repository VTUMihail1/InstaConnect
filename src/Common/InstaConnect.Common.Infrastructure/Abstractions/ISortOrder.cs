using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortOrder
{
    public SortOrder SortOrder { get; }

    public string Order { get; }
}
