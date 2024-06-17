using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.Follows;

public class GetFollowCollectionRequest : CollectionRequest
{
    [FromQuery(Name = "followerName")]
    public string FollowerName { get; set; } = string.Empty;

    [FromQuery(Name = "followingName")]
    public string FollowingName { get; set; } = string.Empty;
}
