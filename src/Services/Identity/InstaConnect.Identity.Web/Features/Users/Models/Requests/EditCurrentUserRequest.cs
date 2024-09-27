using InstaConnect.Identity.Web.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Users.Models.Requests;

public class EditCurrentUserRequest
{
    [FromBody]
    public EditCurrentUserBindingModel EditCurrentUserBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, null);
}
