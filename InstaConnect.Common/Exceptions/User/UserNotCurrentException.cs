using EGames.Common.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class UserNotCurrentException : UserException
    {
        private const string ERROR_MESSAGE = "User is not current";

        public UserNotCurrentException() : base(ERROR_MESSAGE, EGamesStatusCode.Forbidden)
        {
        }
    }
}
