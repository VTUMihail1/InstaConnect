using System.Security.Claims;

using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
