using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account
{
    public class AccountEmailAlreadyTakenException : BadRequestException
    {
        private const string ERROR_MESSAGE = "Email already taken";

        public AccountEmailAlreadyTakenException() : base(ERROR_MESSAGE)
        {
        }

        public AccountEmailAlreadyTakenException(Exception exception) : base(ERROR_MESSAGE, exception)
        {
        }
    }
}
