namespace InstaConnect.Identity.Presentation.Features.Users.Models.Forms;

public record UpdateUserApiForm(
	string Name,
	string FirstName,
	string LastName,
	string Email,
	IFormFile? ProfileImage
);
