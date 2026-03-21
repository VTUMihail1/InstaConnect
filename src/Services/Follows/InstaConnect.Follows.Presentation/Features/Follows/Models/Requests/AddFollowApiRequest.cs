namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record AddFollowApiRequest(
    [UserIdFromClaim] string FollowerId,
    [FromRoute] string FollowingId
);
