using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Post comment like not found";

    public PostCommentLikeNotFoundException() : base(ErrorMessage)
    {
    }

    public PostCommentLikeNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
