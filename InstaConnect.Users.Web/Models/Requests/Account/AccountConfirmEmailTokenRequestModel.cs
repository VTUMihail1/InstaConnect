using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class AccountConfirmEmailTokenRequestModel
    {
        [FromRoute]
        public string UserId { get; set; }

        [FromRoute]
        public string Token { get; set; }
    }
}
