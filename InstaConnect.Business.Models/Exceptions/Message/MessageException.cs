using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Exceptions.Base;

namespace InstaConnect.Business.Models.Exceptions.Message
{
    public class MessageException : BaseException
    {
        public MessageException(string message, InstaConnectStatusCode statusCode)
            : base(message, statusCode)
        {
        }

        public MessageException(string message, Exception exception, InstaConnectStatusCode statusCode)
            : base(message, exception, statusCode)
        {
        }
    }
}
