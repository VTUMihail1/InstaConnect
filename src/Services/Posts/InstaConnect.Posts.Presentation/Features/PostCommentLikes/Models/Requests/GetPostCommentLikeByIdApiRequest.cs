using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId) : ICurrentUserableApiRequest;
