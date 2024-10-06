using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.PostComment;

public class PostCommentNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Post comment not found";

    public PostCommentNotFoundException() : base(ERROR_MESSAGE)
    {
    }

    public PostCommentNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
