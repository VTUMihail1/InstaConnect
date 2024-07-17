using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.User;

public class GetAllFilteredUsersRequest : CollectionReadRequest
{
    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "firstName")]
    public string FirstName { get; set; } = string.Empty;

    [FromQuery(Name = "lastName")]
    public string LastName { get; set; } = string.Empty;
}
