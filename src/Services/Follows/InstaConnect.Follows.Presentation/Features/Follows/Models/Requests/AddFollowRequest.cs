using System.Security.Claims;

using InstaConnect.Follows.Presentation.Features.Follows.Models.Bodies;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record AddFollowRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddFollowBody Body);
