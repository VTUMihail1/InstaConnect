using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record DeletePostCommentApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId
);
