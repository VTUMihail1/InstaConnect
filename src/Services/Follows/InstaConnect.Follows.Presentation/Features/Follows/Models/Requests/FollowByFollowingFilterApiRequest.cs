namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowByFollowingFilterApiRequest(
    [FromRoute] string FollowingId,
    [FromQuery(Name = "followingName")] string FollowerName = "");
