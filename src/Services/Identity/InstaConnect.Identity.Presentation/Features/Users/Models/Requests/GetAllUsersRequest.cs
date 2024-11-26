using InstaConnect.Shared.Presentation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class GetAllUsersRequest : CollectionReadRequest
{
    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "firstName")]
    public string FirstName { get; set; } = string.Empty;

    [FromQuery(Name = "lastName")]
    public string LastName { get; set; } = string.Empty;
}
