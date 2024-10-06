using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Users.Models.Requests;

public class ResendUserConfirmEmailRequest
{
    [FromRoute]
    public string Email { get; set; } = string.Empty;
}
