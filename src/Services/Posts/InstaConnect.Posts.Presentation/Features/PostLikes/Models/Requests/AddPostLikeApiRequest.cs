using System.Security.Claims;

namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record AddPostLikeApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId
);
