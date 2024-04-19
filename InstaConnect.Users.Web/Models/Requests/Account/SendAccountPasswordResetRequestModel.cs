using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class SendAccountPasswordResetRequestModel
    {
        [FromRoute]
        public string Email { get; set; }
    }
}
