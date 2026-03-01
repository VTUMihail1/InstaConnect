using System.Security.Claims;

using InstaConnect.Follows.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetFollowByIdApiRequest(
    [FromRoute] string FollowerId,
    [FromRoute] string FollowingId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId) : ICurrentUserableApiRequest;
