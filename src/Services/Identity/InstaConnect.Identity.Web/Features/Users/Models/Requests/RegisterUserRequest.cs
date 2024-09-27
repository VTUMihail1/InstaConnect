using InstaConnect.Identity.Web.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Users.Models.Requests;

public class RegisterUserRequest
{
    [FromForm]
    public RegisterUserBindingModel RegisterUserBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null!);
}
