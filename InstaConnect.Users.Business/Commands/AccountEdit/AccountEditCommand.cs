using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountEdit
{
    public class AccountEditCommand : ICommand
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
