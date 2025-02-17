using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record UpdatePostRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] UpdatePostBody Body
);
