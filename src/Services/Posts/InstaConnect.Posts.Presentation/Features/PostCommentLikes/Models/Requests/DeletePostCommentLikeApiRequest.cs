using System.Security.Claims;

namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId
);
