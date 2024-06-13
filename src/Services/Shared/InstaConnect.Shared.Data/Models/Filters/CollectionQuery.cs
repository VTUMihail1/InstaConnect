using InstaConnect.Shared.Data.Enum;

namespace InstaConnect.Shared.Data.Models.Filters;

public class CollectionQuery
{
    public SortOrder SortOrder { get; set; } = SortOrder.ASC;

    public string SortPropertyName { get; set; } = "CreatedAt";

    public int Offset { get; set; } = 0;

    public int Limit { get; set; } = int.MaxValue;
}
