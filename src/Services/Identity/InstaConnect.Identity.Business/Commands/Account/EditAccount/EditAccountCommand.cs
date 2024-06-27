using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.EditAccount;

public class EditAccountCommand : ICommand
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }
}
