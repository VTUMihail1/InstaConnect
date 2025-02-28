using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record AddPostCommentRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddPostCommentBody Body);
