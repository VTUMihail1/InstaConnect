namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record DeleteFollowApiRequest(
    [UserIdFromClaim] string FollowerId,
    [FromRoute] string FollowingId
);
