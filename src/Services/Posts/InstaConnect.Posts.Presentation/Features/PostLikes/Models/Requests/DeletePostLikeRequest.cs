using InstaConnect.Shared.Presentation.Binders.FromClaim;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record DeletePostLikeRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
