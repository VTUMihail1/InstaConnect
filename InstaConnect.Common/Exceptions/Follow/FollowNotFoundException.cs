using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class FollowNotFoundException : FollowException
    {
        private const string ERROR_MESSAGE = "Follow not found";

        public FollowNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
