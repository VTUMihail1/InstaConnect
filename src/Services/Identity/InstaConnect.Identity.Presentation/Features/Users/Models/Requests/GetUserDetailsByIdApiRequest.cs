using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserDetailsByIdApiRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentId);
