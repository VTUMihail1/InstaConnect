using InstaConnect.Common.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Post comment not found";

    public PostCommentNotFoundException() : base(ErrorMessage)
    {
    }

    public PostCommentNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
