namespace InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;

public class EditCurrentAccountProfileImageBindingModel
{
    public EditCurrentAccountProfileImageBindingModel(IFormFile profileImage)
    {
        ProfileImage = profileImage;
    }

    public IFormFile ProfileImage { get; set; }
}
