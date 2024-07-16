using InstaConnect.Shared.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Shared.Web.Models.Filters;

public class CollectionRequest
{
    [FromQuery(Name = "sortOrder")]
    public string SortOrder { get; set; } = "ASC";

    [FromQuery(Name = "sortPropertyName")]
    public string SortPropertyName { get; set; } = "CreatedAt";

    [FromQuery(Name = "offset")]
    public int Offset { get; set; } = 0;

    [FromQuery(Name = "limit")]
    public int Limit { get; set; } = 20;
}
