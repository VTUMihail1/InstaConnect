using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class RegisterUserRequest
{
    [FromForm(Name = "")]
    public RegisterUserBindingModel RegisterUserBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null!);
}
