using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.ResetAccountPassword
{
    public class ResetAccountPasswordCommand : ICommand
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
