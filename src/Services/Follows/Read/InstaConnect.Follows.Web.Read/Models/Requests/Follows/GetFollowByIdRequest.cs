using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Read.Models.Requests.Follows;

public class GetFollowByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
