namespace InstaConnect.Shared.Business.Models.Filters;

public class CollectionModel
{
    public string SortOrder { get; set; } = string.Empty;

    public string SortPropertyName { get; set; } = string.Empty;

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10000;
}
