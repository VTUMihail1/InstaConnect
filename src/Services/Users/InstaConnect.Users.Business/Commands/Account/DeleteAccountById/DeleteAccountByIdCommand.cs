using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Users.Business.Commands.Account.DeleteAccountById;

public class DeleteAccountByIdCommand : ICommand
{
    public string Id { get; set; }
}
