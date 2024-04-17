using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account
{
    public class AccountUsernameAlreadyTakenException : BadRequestException
    {
        private const string ERROR_MESSAGE = "Username already taken";

        public AccountUsernameAlreadyTakenException() : base(ERROR_MESSAGE)
        {
        }

        public AccountUsernameAlreadyTakenException(Exception exception) : base(ERROR_MESSAGE, exception)
        {
        }
    }
}
