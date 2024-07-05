using InstaConnect.Identity.Web.Models.Binding.Account;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class EditCurrentAccountRequest
{
    [FromBody]
    public EditCurrentAccountBindingModel EditCurrentAccountBindingModel { get; set; } = new();
}
