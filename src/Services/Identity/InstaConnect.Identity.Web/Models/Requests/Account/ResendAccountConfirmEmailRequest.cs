using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class ResendAccountConfirmEmailRequest
{
    [FromRoute]
    public string Email { get; set; } = string.Empty;
}
