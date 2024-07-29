using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class ConfirmAccountEmailTokenRequest
{
    [FromRoute]
    public string UserId { get; set; } = string.Empty;

    [FromRoute]
    public string Token { get; set; } = string.Empty;
}
