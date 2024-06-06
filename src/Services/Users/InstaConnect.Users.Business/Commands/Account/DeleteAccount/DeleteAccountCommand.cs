using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.DeleteAccount;

public class DeleteAccountCommand : ICommand
{
    public string Id { get; set; }
}
