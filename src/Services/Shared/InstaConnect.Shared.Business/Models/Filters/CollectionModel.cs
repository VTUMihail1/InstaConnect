using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Business.Models.Filters;

public class CollectionModel
{
    public string SortOrder { get; set; } = string.Empty;

    public string SortPropertyName { get; set; } = string.Empty;

    public int Offset { get; set; } = 0;

    public int Limit { get; set; } = int.MaxValue;
}
