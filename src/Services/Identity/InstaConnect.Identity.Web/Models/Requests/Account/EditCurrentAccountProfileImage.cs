using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class EditCurrentAccountProfileImageRequest
{
    [FromForm]
    public EditCurrentAccountProfileImageBindingModel EditCurrentAccountProfileImageBindingModel { get; set; } = new(null!);
}
