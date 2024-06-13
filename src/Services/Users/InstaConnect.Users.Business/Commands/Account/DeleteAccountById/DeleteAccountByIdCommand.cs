using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.DeleteAccountById;

public class DeleteAccountByIdCommand : ICommand
{
    public string Id { get; set; }
}
