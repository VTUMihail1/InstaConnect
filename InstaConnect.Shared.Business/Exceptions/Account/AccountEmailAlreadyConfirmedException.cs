using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account
{
    public class AccountEmailAlreadyConfirmedException : BadRequestException
    {
        private const string ERROR_MESSAGE = "Email already confirmed";

        public AccountEmailAlreadyConfirmedException() : base(ERROR_MESSAGE)
        {
        }

        public AccountEmailAlreadyConfirmedException(Exception exception) : base(ERROR_MESSAGE, exception)
        {
        }
    }
}
