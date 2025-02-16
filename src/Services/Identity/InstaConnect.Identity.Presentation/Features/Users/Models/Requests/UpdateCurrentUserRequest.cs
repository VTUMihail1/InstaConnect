using System.Security.Claims;

using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Shared.Presentation.Binders.FromClaim;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record UpdateCurrentUserRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string Id,
    [FromForm(Name = "")] UpdateUserForm Form
);
