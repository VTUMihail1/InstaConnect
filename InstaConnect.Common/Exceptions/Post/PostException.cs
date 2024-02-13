using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Exceptions.Post
{
    public class PostException : BaseException
    {
        public PostException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public PostException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
