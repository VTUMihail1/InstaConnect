using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Exceptions.Base;

namespace InstaConnect.Business.Models.Exceptions.Post
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
