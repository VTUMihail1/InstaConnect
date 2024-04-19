using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class ResendAccountConfirmEmailRequestModel
    {
        [FromRoute]
        public string Email { get; set; }
    }
}
