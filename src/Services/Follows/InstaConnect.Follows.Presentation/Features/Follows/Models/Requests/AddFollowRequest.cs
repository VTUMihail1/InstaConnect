using System.Security.Claims;

using InstaConnect.Follows.Presentation.Features.Follows.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record AddFollowRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddFollowBody Body);
