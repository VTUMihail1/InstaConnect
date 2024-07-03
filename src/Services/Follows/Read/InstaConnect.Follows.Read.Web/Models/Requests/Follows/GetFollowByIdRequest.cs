using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Read.Web.Models.Requests.Follows;

public class GetFollowByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
