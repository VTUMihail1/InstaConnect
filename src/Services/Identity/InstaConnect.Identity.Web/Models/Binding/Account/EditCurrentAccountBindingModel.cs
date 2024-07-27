namespace InstaConnect.Identity.Web.Models.Binding.Account;

public class EditCurrentAccountBindingModel
{
    public EditCurrentAccountBindingModel(string userName, string firstName, string lastName)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
    }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
