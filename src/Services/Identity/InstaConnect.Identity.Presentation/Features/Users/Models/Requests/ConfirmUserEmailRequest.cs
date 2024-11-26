using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class ConfirmUserEmailRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;
}
