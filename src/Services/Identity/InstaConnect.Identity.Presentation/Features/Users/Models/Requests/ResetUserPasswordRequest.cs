using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class ResetUserPasswordRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;

    [FromBody]
    public ResetUserPasswordBindingModel ResetUserPasswordBindingModel { get; set; } = new(string.Empty, string.Empty);
}
