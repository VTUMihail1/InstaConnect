using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Read.Models.Requests.Follows;

public class GetAllFilteredFollowsRequest : CollectionRequest
{
    [FromQuery(Name = "followerName")]
    public string FollowerName { get; set; } = string.Empty;

    [FromQuery(Name = "followingName")]
    public string FollowingName { get; set; } = string.Empty;
}
