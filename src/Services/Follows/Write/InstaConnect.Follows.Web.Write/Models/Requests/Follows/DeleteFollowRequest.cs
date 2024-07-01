using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Write.Models.Requests.Follows;

public class DeleteFollowRequest
{
    [FromRoute]
    public string Id { get; set; }
}
