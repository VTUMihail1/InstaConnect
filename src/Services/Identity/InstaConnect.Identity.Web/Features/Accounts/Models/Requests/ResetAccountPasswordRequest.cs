using InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class ResetAccountPasswordRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;

    [FromBody]
    public ResetAccountPasswordBindingModel ResetAccountPasswordBindingModel { get; set; } = new(string.Empty, string.Empty);
}
