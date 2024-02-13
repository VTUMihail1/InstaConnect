using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Exceptions.PostCommentLike
{
    public class PostCommentLikeException : BaseException
    {
        public PostCommentLikeException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public PostCommentLikeException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
