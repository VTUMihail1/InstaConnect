using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record DeletePostApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
