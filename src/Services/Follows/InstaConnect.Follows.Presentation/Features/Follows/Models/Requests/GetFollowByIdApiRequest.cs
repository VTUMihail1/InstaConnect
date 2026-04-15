using InstaConnect.Follows.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetFollowByIdApiRequest(
    [FromRoute] string FollowerId,
    [FromRoute] string FollowingId,
    [UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
