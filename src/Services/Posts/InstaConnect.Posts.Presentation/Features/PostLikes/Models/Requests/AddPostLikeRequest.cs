using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record AddPostLikeRequest(
    [FromRoute] string PostId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddPostLikeBody Body
);
