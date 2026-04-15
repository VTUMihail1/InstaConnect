using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record AddUserApiRequest(
    [FromForm(Name = "")] AddUserApiForm Form
);
