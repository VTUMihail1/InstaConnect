using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteAccount;

public class DeleteCurrentAccountCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;
}
