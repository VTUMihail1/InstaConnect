using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record AddPostApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId,
    [FromBody] AddPostApiBody Body
);
