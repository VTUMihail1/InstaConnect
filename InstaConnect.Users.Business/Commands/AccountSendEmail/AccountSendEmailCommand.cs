using MediatR;

namespace InstaConnect.Users.Business.Commands.Account
{
    public class AccountSendEmailDTO : IRequest
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string PlainText { get; set; }

        public string Html { get; set; }
    }
}
