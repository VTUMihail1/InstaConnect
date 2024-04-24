using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.PostCommentLike
{
    public class PostCommentLikeNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE = "Post comment like not found";

        public PostCommentLikeNotFoundException() : base(ERROR_MESSAGE)
        {
        }

        public PostCommentLikeNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
        {
        }
    }
}
