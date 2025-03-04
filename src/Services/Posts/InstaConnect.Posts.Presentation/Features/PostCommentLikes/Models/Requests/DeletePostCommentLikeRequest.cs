using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeRequest(
    [FromRoute] string PostId,
    [FromRoute] string PostCommentId,
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
