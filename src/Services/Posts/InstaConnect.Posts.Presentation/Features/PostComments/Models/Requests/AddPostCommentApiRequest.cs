using System.Security.Claims;

using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record AddPostCommentApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string UserId,
    [FromBody] AddPostCommentApiBody Body
);
