using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountResetPassword
{
    public class AccountResetPasswordCommand : ICommand
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
