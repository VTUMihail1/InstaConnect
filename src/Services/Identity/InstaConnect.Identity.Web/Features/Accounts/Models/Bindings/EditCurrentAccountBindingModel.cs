namespace InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;

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
