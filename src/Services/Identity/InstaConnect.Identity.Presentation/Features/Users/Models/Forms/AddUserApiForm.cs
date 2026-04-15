namespace InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

public record AddUserApiForm(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage
);
