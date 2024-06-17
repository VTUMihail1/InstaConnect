using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.User;

public class GetUserDetailedByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
