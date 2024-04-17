using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountDelete
{
    public class AccountDeleteCommand : ICommand
    {
        public string Id { get; set; }
    }
}
