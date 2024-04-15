using InstaConnect.Shared.Exceptions.Base;
using InstaConnect.Shared.Models.Enum;

namespace InstaConnect.Shared.Exceptions.Account
{
    public class AccountException : BaseException
    {
        public AccountException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public AccountException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
