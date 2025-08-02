using System.Security.Claims;

namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record DeletePostLikeApiRequest(
    [FromRoute] string Id,
    [FromRoute] string LikeId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId
);
