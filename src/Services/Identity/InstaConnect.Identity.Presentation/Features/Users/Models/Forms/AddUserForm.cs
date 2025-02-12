namespace InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

public record AddUserForm(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage
);
