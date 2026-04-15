using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record UpdateCurrentUserApiRequest(
    [UserIdFromClaim] string Id,
    [FromForm(Name = "")] UpdateUserApiForm Form
);
