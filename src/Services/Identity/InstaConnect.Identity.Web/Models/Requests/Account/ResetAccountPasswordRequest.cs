using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class ResetAccountPasswordRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;

    [FromBody]
    public ResetAccountPasswordBindingModel ResetAccountPasswordBindingModel { get; set; } = new(string.Empty, string.Empty);
}
