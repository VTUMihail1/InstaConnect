using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record AddUserRequest(
    [FromForm(Name = "")] AddUserForm Form
);
