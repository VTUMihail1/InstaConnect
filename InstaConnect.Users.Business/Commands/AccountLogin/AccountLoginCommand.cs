using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Commands.AccountLogin
{
    public class AccountLoginCommand : ICommand<AccountViewDTO>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
