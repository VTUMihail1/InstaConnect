using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account;

public class ConfirmAccountEmailTokenRequest
{
    [FromRoute]
    public string UserId { get; set; }

    [FromRoute]
    public string Token { get; set; }
}
