using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class SendAccountPasswordResetRequest
{
    [FromRoute]
    public string Email { get; set; } = string.Empty;
}
