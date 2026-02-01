using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetPostByIdApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId) : ICurrentUserableApiRequest;
