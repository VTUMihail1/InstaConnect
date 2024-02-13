using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class PostLikeNotFoundException : PostLikeException
    {
        private const string ERROR_MESSAGE = "Post like not found";

        public PostLikeNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
