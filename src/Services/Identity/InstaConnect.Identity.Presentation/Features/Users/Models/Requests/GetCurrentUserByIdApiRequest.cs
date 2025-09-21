using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserByIdApiRequest([FromClaim(ClaimTypes.NameIdentifier)] string Id);
