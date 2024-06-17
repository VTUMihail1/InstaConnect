using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.User;

public class GetUserByNameRequest
{
    [FromRoute]
    public string UserName { get; set; }
}
