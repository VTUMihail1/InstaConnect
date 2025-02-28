using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Post not found";

    public PostNotFoundException() : base(ErrorMessage)
    {
    }

    public PostNotFoundException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
