using InstaConnect.Shared.Messaging;
using InstaConnect.Users.Business.Models;
using MediatR;

namespace InstaConnect.Users.Business.Commands.Account
{
    public class AccountLoginCommand : ICommand<AccountViewDTO>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
