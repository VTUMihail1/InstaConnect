using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Exceptions.PostLike
{
    public class PostLikeNotFoundException : PostLikeException
    {
        private const string ERROR_MESSAGE = "Post like not found";

        public PostLikeNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
