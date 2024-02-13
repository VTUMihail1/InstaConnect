using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Exceptions.Base;

namespace InstaConnect.Business.Models.Exceptions.PostLike
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
