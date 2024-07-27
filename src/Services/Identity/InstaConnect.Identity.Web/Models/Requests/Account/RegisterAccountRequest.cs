using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class RegisterAccountRequest
{
    [FromForm]
    public RegisterAccountBindingModel RegisterAccountBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null!);
}
