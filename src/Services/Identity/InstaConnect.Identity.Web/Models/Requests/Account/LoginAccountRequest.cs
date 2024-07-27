using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class LoginAccountRequest
{
    [FromBody]
    public LoginAccountBindingModel LoginAccountBindingModel { get; set; } = new(string.Empty, string.Empty);
}
