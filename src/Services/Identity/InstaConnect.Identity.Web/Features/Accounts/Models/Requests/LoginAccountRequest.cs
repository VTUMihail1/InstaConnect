using InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class LoginAccountRequest
{
    [FromBody]
    public LoginAccountBindingModel LoginAccountBindingModel { get; set; } = new(string.Empty, string.Empty);
}
