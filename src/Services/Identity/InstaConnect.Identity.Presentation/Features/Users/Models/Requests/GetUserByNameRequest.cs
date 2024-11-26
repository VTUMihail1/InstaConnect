using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class GetUserByNameRequest
{
    [FromRoute]
    public string UserName { get; set; } = string.Empty;
}
