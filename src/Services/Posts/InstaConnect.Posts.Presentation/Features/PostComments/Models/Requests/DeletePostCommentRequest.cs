using System.Security.Claims;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record DeletePostCommentRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
