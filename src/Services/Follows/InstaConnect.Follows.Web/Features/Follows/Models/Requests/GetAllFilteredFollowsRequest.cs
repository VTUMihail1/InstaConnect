using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Requests;

public class GetAllFilteredFollowsRequest : CollectionReadRequest
{
    [FromQuery(Name = "followerName")]
    public string FollowerName { get; set; } = string.Empty;

    [FromQuery(Name = "followingName")]
    public string FollowingName { get; set; } = string.Empty;
}
