using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class PostCommentLikeFoundException : PostCommentLikeException
    {
        private const string ERROR_MESSAGE = "Post comment like not found";

        public PostCommentLikeFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
