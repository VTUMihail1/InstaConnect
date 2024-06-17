using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account;

public class SendAccountPasswordResetRequest
{
    [FromRoute]
    public string Email { get; set; }
}
