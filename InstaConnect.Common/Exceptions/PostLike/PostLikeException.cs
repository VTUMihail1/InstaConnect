using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Exceptions.User
{
    public class PostLikeException : BaseException
    {
        public PostLikeException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public PostLikeException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
