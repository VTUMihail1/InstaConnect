using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record AddPostCommentLikeRequest(
    [FromRoute] string PostId,
    [FromRoute] string PostCommentId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
