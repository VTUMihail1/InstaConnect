using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Write.Web.Models.Requests.Follows;

public class DeleteFollowRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
