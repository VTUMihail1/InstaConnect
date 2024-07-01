using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.User;

public class GetUserByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
