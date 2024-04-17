using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class PasswordRequestModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
