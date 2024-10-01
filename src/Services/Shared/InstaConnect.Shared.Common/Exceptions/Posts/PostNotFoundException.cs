using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.Posts;

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
