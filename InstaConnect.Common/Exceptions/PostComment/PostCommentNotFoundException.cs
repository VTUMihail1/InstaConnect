using InstaConnect.Business.Models.Enums;
using InstaConnect.Common.Exceptions.User;

namespace EGames.Common.Exceptions.User
{
    public class PostCommentNotFoundException : PostCommentException
    {
        private const string ERROR_MESSAGE = "Post comment not found";

        public PostCommentNotFoundException() : base(ERROR_MESSAGE, InstaConnectStatusCode.NotFound)
        {
        }
    }
}
