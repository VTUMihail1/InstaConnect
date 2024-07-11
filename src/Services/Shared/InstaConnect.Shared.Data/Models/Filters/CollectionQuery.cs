using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public class CollectionQuery
{
    public SortOrder SortOrder { get; set; } = SortOrder.ASC;

    public string SortPropertyName { get; set; } = "CreatedAt";

    public int Offset { get; set; } = default;

    public int Limit { get; set; } = int.MaxValue;
}
