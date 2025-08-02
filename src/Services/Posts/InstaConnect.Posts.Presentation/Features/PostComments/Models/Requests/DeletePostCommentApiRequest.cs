using System.Security.Claims;

namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record DeletePostCommentApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId
);
