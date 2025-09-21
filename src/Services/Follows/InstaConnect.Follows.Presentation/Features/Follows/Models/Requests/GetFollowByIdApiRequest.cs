using System.Security.Claims;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetFollowByIdApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string FollowerId,
    [FromRoute] string FollowingId);
