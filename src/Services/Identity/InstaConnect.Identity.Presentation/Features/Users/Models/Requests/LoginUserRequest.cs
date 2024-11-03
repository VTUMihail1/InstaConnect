using InstaConnect.Identity.Web.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Users.Models.Requests;

public class LoginUserRequest
{
    [FromBody]
    public LoginUserBindingModel LoginUserBindingModel { get; set; } = new(string.Empty, string.Empty);
}
