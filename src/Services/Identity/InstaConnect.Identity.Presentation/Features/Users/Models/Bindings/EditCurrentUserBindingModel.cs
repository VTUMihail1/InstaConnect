namespace InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;

public class EditCurrentUserBindingModel
{
    public EditCurrentUserBindingModel(string userName, string firstName, string lastName, IFormFile? profileImage)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
    }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IFormFile? ProfileImage { get; set; }
}
