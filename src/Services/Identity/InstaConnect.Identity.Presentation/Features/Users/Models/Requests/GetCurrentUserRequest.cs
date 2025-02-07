using InstaConnect.Shared.Presentation.Binders.FromClaim;
using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserRequest([FromClaim(ClaimTypes.NameIdentifier)] string Id);
