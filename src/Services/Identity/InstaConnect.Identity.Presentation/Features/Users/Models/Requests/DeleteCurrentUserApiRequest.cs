using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record DeleteCurrentUserApiRequest([FromClaim(ClaimTypes.NameIdentifier)] string CurrentId);
