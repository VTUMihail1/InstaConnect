using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Business.Models.Exceptions.Post
{
    public class PostNotFoundException : PostException
    {
        private const string ERROR_MESSAGE = "Post not found";

        public PostNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
