using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Requests;

public class GetFollowByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
