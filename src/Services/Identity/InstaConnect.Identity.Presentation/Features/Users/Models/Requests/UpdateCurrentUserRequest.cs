using System.Security.Claims;

using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record UpdateCurrentUserRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string Id,
    [FromForm(Name = "")] UpdateUserForm Form
);
