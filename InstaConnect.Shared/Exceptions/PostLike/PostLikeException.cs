using InstaConnect.Business.Models.Enums;
using InstaConnect.Shared.Exceptions.Base;

namespace InstaConnect.Shared.Exceptions.PostLike
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
