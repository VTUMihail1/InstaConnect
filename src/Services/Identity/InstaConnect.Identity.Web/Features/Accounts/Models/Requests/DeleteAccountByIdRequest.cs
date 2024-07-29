using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Features.Accounts.Models.Requests;

public class DeleteAccountByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
