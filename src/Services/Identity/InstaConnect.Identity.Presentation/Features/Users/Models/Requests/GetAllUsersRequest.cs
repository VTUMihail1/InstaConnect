using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Users.Models.Requests;

public class GetAllUsersRequest : CollectionReadRequest
{
    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "firstName")]
    public string FirstName { get; set; } = string.Empty;

    [FromQuery(Name = "lastName")]
    public string LastName { get; set; } = string.Empty;
}
