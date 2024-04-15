using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Shared.Exceptions.PostCommentLike
{
    public class PostCommentLikeFoundException : PostCommentLikeException
    {
        private const string ERROR_MESSAGE = "Post comment like not found";

        public PostCommentLikeFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
