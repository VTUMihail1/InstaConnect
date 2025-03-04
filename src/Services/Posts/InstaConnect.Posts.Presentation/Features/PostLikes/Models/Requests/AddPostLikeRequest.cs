using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record AddPostLikeRequest(
    [FromRoute] string PostId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
