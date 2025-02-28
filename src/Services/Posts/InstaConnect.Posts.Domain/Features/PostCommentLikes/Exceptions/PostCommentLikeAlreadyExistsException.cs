using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeAlreadyExistsException : BadRequestException
{
    private const string ErrorMessage = "Post comment like already exists";

    public PostCommentLikeAlreadyExistsException() : base(ErrorMessage)
    {
    }

    public PostCommentLikeAlreadyExistsException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
