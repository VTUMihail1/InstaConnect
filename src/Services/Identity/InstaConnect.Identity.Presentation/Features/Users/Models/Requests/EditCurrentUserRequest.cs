using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class EditCurrentUserRequest
{
    [FromForm(Name = "")]
    public EditCurrentUserBindingModel EditCurrentUserBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, null);
}
