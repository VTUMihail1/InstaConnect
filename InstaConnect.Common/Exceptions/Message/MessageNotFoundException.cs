using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class MessageNotFoundException : MessageException
    {
        private const string ERROR_MESSAGE = "Message not found";

        public MessageNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
