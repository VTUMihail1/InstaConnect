using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.User;

public class GetUserDetailedByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
