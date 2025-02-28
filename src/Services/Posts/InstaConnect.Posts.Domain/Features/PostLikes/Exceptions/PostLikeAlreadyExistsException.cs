using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeAlreadyExistsException : BadRequestException
{
    private const string ErrorMessage = "Post like already exists";

    public PostLikeAlreadyExistsException() : base(ErrorMessage)
    {
    }

    public PostLikeAlreadyExistsException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
