using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account;

public class DeleteAccountByIdRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
