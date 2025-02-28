using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Post like not found";

    public PostLikeNotFoundException() : base(ErrorMessage)
    {
    }

    public PostLikeNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
