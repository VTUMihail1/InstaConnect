using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account
{
    public class AccountDeleteRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
