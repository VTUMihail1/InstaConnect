using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class DeleteAccountByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
