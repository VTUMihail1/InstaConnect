using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record DeletePostLikeRequest(
    [FromRoute] string PostId,
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
