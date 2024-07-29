using InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class EditCurrentAccountProfileImageRequest
{
    [FromForm]
    public EditCurrentAccountProfileImageBindingModel EditCurrentAccountProfileImageBindingModel { get; set; } = new(null!);
}
