using System.Security.Claims;

using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserDetailsApiRequest([FromClaim(ClaimTypes.NameIdentifier)] string CurrentId) : ICurrentUserableApiRequest;
