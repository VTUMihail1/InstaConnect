using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserDetailsApiRequest([FromClaim(ClaimTypes.NameIdentifier)] string Id);
