using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class EditCurrentAccountRequest
{
    [FromBody]
    public EditAccountBindingModel EditAccountBindingModel { get; set; } = new();
}
