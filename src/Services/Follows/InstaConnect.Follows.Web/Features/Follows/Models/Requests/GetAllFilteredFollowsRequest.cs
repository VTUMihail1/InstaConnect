using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Requests;

public class GetAllFilteredFollowsRequest : CollectionReadRequest
{
    [FromQuery(Name = "followerId")]
    public string FollowerId { get; set; } = string.Empty;

    [FromQuery(Name = "followerName")]
    public string FollowerName { get; set; } = string.Empty;

    [FromQuery(Name = "followingId")]
    public string FollowingId { get; set; } = string.Empty;

    [FromQuery(Name = "followingName")]
    public string FollowingName { get; set; } = string.Empty;
}
