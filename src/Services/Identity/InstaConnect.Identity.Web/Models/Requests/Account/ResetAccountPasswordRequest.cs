using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class ResetAccountPasswordRequest
{
    [FromRoute]
    public string UserId { get; set; }

    [FromRoute]
    public string Token { get; set; }

    [FromBody]
    public PasswordBodyRequest PasswordBodyRequestModel { get; set; }
}
