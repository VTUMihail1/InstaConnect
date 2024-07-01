using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;

public class DeleteAccountByIdCommand : ICommand
{
    public string Id { get; set; } = string.Empty;
}
