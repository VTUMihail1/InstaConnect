namespace InstaConnect.Identity.Web.Models.Binding.Account;

public class RegisterAccountBindingModel
{
    public RegisterAccountBindingModel(
        string userName, 
        string email, 
        string password, 
        string confirmPassword, 
        string firstName, 
        string lastName, 
        IFormFile? profileImage)
    {
        UserName = userName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
    }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IFormFile? ProfileImage { get; set; }
}
