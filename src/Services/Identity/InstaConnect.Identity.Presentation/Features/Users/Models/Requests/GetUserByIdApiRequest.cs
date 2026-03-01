using System.Security.Claims;

using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserByIdApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentId) : ICurrentUserableApiRequest;
