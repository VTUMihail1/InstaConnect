using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record UpdatePostApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] UpdatePostApiBody Body
);
