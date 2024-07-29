using InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class EditCurrentAccountRequest
{
    [FromBody]
    public EditCurrentAccountBindingModel EditCurrentAccountBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty);
}
