using InstaConnect.Shared.Common.Exceptions.Base;

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
