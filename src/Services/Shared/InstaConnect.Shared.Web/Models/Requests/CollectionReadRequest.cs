using InstaConnect.Shared.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Shared.Web.Models.Requests;

public class CollectionReadRequest
{
    [FromQuery(Name = "sortOrder")]
    public SortOrder SortOrder { get; set; } = SortOrder.ASC;

    [FromQuery(Name = "sortPropertyName")]
    public string SortPropertyName { get; set; } = "CreatedAt";

    [FromQuery(Name = "page")]
    public int Page { get; set; } = 1;

    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 10000;
}
