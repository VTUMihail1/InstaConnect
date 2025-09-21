using System.Security.Claims;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record DeleteFollowApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string FollowerId,
    [FromRoute] string FollowingId
);
