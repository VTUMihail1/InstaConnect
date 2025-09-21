namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowByFollowerFilterApiRequest(
    [FromRoute] string FollowerId,
    [FromQuery(Name = "followingName")] string FollowingName = "");
