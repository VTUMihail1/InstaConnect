using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Exceptions.Account
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
