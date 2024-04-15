using InstaConnect.Business.Models.Enums;
using InstaConnect.Shared.Exceptions.Base;

namespace InstaConnect.Shared.Exceptions.Post
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
