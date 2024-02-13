using InstaConnect.Business.Models.Enums;

namespace InstaConnect.Common.Exceptions.PostComment
{
    public class PostCommentNotFoundException : PostCommentException
    {
        private const string ERROR_MESSAGE = "Post comment not found";

        public PostCommentNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
