using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Exceptions.Message
{
    public class MessageNotFoundException : MessageException
    {
        private const string ERROR_MESSAGE = "Message not found";

        public MessageNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
