using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Exceptions.Base;

namespace InstaConnect.Business.Models.Exceptions.User
{
    public class UserException : BaseException
    {
        public UserException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public UserException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
