using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record UpdatePostCommentApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId,
    [FromBody] UpdatePostCommentApiBody Body
);
