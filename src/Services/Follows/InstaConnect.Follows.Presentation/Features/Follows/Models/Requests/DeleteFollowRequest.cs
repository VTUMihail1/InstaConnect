using System.Security.Claims;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record DeleteFollowRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId);
