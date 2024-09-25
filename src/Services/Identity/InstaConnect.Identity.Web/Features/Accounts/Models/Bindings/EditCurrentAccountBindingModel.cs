namespace InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;

public class EditCurrentAccountBindingModel
{
    public EditCurrentAccountBindingModel(string userName, string firstName, string lastName, IFormFile? profileImage)
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
