using InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class RegisterAccountRequest
{
    [FromForm]
    public RegisterAccountBindingModel RegisterAccountBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null!);
}
