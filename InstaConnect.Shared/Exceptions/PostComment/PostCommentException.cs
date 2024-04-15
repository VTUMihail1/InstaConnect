using InstaConnect.Business.Models.Enums;
using InstaConnect.Shared.Exceptions.Base;

namespace InstaConnect.Shared.Exceptions.PostComment
{
    public class PostCommentException : BaseException
    {
        public PostCommentException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public PostCommentException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
