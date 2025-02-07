using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class AddForgotPasswordTokenRequest
{
    [FromRoute]
    public string Email { get; set; } = string.Empty;
}
