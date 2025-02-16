using System.Security.Claims;

using InstaConnect.Shared.Presentation.Binders.FromClaim;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record DeleteFollowRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId);
