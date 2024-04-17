using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class AccountResetPasswordRequestModel
    {
        [FromRoute]
        public string UserId { get; set; }

        [FromRoute]
        public string Token { get; set; }

        [FromBody]
        public PasswordRequestModel PasswordRequestModel { get; set; }
    }
}
