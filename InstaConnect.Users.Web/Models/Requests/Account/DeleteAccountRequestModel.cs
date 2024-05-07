using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Models.Requests.Account;

public class DeleteAccountRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
