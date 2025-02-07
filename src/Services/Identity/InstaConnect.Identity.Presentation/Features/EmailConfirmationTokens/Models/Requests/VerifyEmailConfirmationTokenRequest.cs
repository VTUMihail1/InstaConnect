using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class VerifyEmailConfirmationTokenRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;
}
