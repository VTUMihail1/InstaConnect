using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class UserNotFoundException : UserException
    {
        private const string ERROR_MESSAGE = "User not found";

        public UserNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
