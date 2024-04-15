using InstaConnect.Shared.Messaging;

namespace InstaConnect.Users.Business.Commands.Account
{
    public class AccountEditCommand : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
