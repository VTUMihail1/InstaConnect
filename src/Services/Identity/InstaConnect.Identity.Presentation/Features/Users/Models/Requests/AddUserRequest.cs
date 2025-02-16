using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record AddUserRequest(
    [FromForm(Name = "")] AddUserForm Form
);
