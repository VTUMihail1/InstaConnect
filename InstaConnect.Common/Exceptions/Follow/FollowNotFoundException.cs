using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Common.Exceptions.Follow
{
    public class FollowNotFoundException : FollowException
    {
        private const string ERROR_MESSAGE = "Follow not found";

        public FollowNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
