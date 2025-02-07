namespace InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

public record UpdateUserForm(
    string UserName,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage
);
