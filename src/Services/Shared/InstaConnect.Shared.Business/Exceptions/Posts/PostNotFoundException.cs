using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Posts;

public class PostNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "Post not found";

    public PostNotFoundException() : base(ERROR_MESSAGE)
    {
    }

    public PostNotFoundException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
