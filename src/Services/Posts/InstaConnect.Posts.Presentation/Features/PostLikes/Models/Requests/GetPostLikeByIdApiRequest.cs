using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdApiRequest(
    [FromRoute] string Id,
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId) : ICurrentUserableApiRequest;
