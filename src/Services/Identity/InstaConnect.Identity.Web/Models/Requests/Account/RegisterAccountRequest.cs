using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class RegisterAccountRequest
{
    [FromBody]
    public RegisterAccountBindingModel RegisterAccountBindingModel { get; set; } = new();
}
