using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountConfirmEmail
{
    public class AccountConfirmEmailCommand : ICommand
    {
        public string UserId { get; set; }

        public string Token { get; set; }
    }
}
