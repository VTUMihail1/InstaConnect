using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public class CollectionReadQuery
{
    public SortOrder SortOrder { get; set; } = SortOrder.ASC;

    public string SortPropertyName { get; set; } = "CreatedAt";

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10000;
}
