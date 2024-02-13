using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Exceptions.Follow
{
    public class FollowException : BaseException
    {
        public FollowException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public FollowException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
