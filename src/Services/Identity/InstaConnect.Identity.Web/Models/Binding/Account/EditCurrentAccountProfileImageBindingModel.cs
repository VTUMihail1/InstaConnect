namespace InstaConnect.Identity.Web.Models.Binding.Account;

public class EditCurrentAccountProfileImageBindingModel
{
    public EditCurrentAccountProfileImageBindingModel(IFormFile profileImage)
    {
        ProfileImage = profileImage;
    }

    public IFormFile ProfileImage { get; set; }
}
