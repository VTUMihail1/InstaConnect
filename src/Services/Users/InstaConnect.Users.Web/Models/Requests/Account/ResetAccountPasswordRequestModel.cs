using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account;

public class ResetAccountPasswordRequestModel
{
    [FromRoute]
    public string UserId { get; set; }

    [FromRoute]
    public string Token { get; set; }

    [FromBody]
    public PasswordBodyRequestModel PasswordBodyRequestModel { get; set; }
}
