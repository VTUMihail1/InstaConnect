using MediatR;

namespace InstaConnect.Users.Business.Commands.Account
{
    public class AccountResetPasswordDTO : IRequest
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
