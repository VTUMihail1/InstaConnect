using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record AddPostCommentLikeRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddPostCommentLikeBody Body
);
