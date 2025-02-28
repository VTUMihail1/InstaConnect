using System.Security.Claims;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentDetailedUserRequest([FromClaim(ClaimTypes.NameIdentifier)] string Id);
